class ImportForm extends React.Component {
    constructor(props) {
        super(props);
        this.state =
            {
                value: '0',
                selectedFile: null,
                loaded: 0,
                message: "",
            };
        this.handleselectedFile = this.handleselectedFile.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleselectedFile(event) {
        this.setState({
            selectedFile: event.target.files,
            loaded: 0,
        })
    }
    handleChange(event) {
        if (event.target.value == "0") {
            var path = $("#downloadPath").val();
            $("#downloadCsv").attr("href", path + event.target.value + ".csv")
        }
        else {
            $("#downloadCsv").removeAttr("href");
        }
        $(".custom-error").empty();
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        var state_data = this.state;
        var file = this.state.selectedFile;
        if (this.state.value == "0") {
            CallToast("Please select import type to proceed", "F");
            event.preventDefault();
            return false;
        }
        if (this.state.selectedFile == null) {
            CallToast("Pelase select file.", "F");
            event.preventDefault();
            return false;
        }
        if (file.length > 0) {
            var extension = file[0].name.replace(/^.*\./, '');
            if (extension.toLowerCase() != "csv") {
                CallToast("Only .CSV format allowed.", "F");
                event.preventDefault();
                return false;
            }

        }
        InlineLoading(event, 'Show');
        const data = new FormData()
        data.append('file', file[0], file[0].name)
        data.append('reportType', this.state.value);
        $.ajax({
            url: '/Setting/FileUpload',
            type: "POST",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: data,
            async: false,
            success: function (result) {
                if (result.ERROR_FLAG == undefined) {
                    var MyData = result;
                    if (MyData.length > 0) {
                        if (MyData[0].FLAG == "F") {
                            event.target.nextSibling.innerHTML = "<span class='field-validation-error'>" + MyData[0].MESSAGE + "</span>";
                            //$("#data-grid").show();
                            //gridOptions.api.setRowData(MyData);
                            event.preventDefault();
                            return false;
                        }
                        else {
                            event.target.nextSibling.innerHTML = "<span class='field-validation-success'>" + MyData[0].MESSAGE + "</span>";
                            //$("#importfile").val('');
                            //$("#data-grid").hide();
                            //gridOptions.api.setRowData(null);
                            event.preventDefault();
                            return false;
                        }
                    }
                    else {
                        $("#data-grid").hide();
                    }
                }
                else {
                    $("#data-grid").hide();
                    if (result.ERROR_FLAG == "F") {
                        event.target.nextSibling.innerHTML = "<span class='field-validation-error'>" + result.ERROR_MSG + "</span>";
                        event.preventDefault();
                        return false;
                    }
                    else {
                        event.target.nextSibling.innerHTML = "<span class='field-validation-success'>" + result.ERROR_MSG + "</span>";
                        event.preventDefault();
                        return false;
                    }
                }
            },
            error: function (err) {
                InlineLoading(event, 'Hide');
                return false;
            }
        })
    }

    render() {
        return (
            <div>
                <div className="inside-top">
                    <div className="pull-left base-top">
                        <span className="pull-left">Import Configuration</span>
                    </div>
                </div>
                <div className="insidebody">
                    <form noValidate onSubmit={this.handleSubmit}>
                        <ul>
                            <li>
                                <label className="col-lg-2 col-xs-12 col-sm-2">Select Import Type:*</label>
                                <div className="col-lg-10 col-xs-12 col-sm-10 col-md-10">
                                    <select value={this.state.value} onChange={this.handleChange} id="import">
                                        <option value="0">Select Import Type</option>
                                        <option value="product">Product</option>
                                        <option value="listing">Listing</option>
                                    </select>
                                </div>
                            </li>
                            <li>
                                <label className="col-lg-2 col-xs-12 col-sm-2">Choose file:*</label>
                                <div className="col-lg-10 col-xs-12 col-sm-10 col-md-10">
                                    <input type="file" id="importfile" onChange={this.handleselectedFile} />
                                    <span className="dwn"><a id="downloadCsv" download>Download Csv Format</a></span>
                                </div>
                            </li>
                            <li>
                                <label className="col-lg-2 col-xs-12 col-sm-2"></label>
                                <div className="col-lg-10 col-xs-12 col-sm-10 col-md-10">
                                    <button type="submit" className="btn btn-info"><span className="hide"><i className="fa fa-spinner"></i></span> Upload</button>
                                </div>
                            </li>
                        </ul>
                    </form>
                    <div className="custom-error"></div>
                    <hr />
                </div>
            </div>
        );
    }
}
//Render react component into the page
ReactDOM.render(<ImportForm urlPost="/Auth/Login" />, document.getElementById('import-base'));