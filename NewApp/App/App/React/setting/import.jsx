class ImportForm extends React.Component {
    constructor(props) {
        super(props);
        this.state =
            {
                value: '0',
                selectedFile: null,
                loaded: 0,
            };
        this.handleselectedFile = this.handleselectedFile.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleselectedFile = event => {
        this.setState({
            selectedFile: event.target.files,
            loaded: 0,
        })
    }
    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
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
        const data = new FormData()
        data.append('file', file[0], file[0].name)
        data.append('reportType', this.state.value);
        $.ajax({
            url: '/Setting/FileUpload',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: data,
            async: true,
            success: function (result) {
                console.log(result);
            },
            error: function (err) {
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
                                    <select value={this.state.value} onChange={this.handleChange.bind(this)} id="import">
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
                    <span className="pull-right"><a href="javascript:void(0)" download >Download Csv Format</a></span>
                    <hr />
                </div>
            </div>
        );
    }
}
//Render react component into the page
ReactDOM.render(<ImportForm urlPost="/Auth/Login" />, document.getElementById('import-base'));