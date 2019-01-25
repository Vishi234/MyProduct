class ImportForm extends React.Component {
    constructor(props) {
        super(props);
        this.state =
            {
                value: '0',
                selectedFile: null,
                loaded: 0,
                message: "",
                messageClass: "",
                downloadPath: ""
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
        this.setState.message = '';
        $("#myGrid").empty();
    }
    handleChange(event) {
        if (event.target.value == "0") {
            var path = $("#downloadPath").val();
            this.setState.downloadPath = path + event.target.value + ".csv";
        }
        else {
            this.setState.downloadPath = "javascript:void(0)";
        }
        this.setState.message = '';
        $("#myGrid").empty();
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        this.setState.message = '';
        $("#myGrid").empty();
        var file = this.state.selectedFile;
        if (this.state.value == "0") {
            this.setState
                ({
                    message: "Please select import type to proceed.",
                    messageClass: 'field-validation-error'
                })
            event.preventDefault();
            return false;
        }
        if (this.state.selectedFile == null) {
            this.setState
                ({
                    message: "Please select file.",
                    messageClass: 'field-validation-error'
                })
            event.preventDefault();
            return false;
        }
        if (file.length > 0) {
            var extension = file[0].name.replace(/^.*\./, '');
            if (extension.toLowerCase() != "csv") {
                this.setState
                    ({
                        message: "Only .CSV format allowed.",
                        messageClass: 'field-validation-error'
                    })
                event.preventDefault();
                return false;
            }

        }
        const data = new FormData()
        data.append('file', file[0], file[0].name)
        data.append('reportType', this.state.value);

        axios.post("/Setting/FileUpload", data, {
            onUploadProgress: ProgressEvent => {
                InlineLoading("upload", 'Show');
            },
        }).then(res => {
            InlineLoading("upload", 'Hide');
            var errordiv = document.getElementById("custom-error");
            if (res.data[1] == undefined) {
                var result = res.data[0];

                if (result.ERROR_FLAG == undefined) {
                    var MyData = result;
                    if (MyData.FLAG == "F") {
                        this.setState
                            ({
                                message: MyData.MESSAGE,
                                messageClass: 'field-validation-error'
                            })
                    }
                    else {
                        this.setState
                            ({
                                message: MyData.MESSAGE,
                                messageClass: 'field-validation-success'
                            })
                    }
                }
                else {
                    if (result.ERROR_FLAG == "F") {
                        this.setState
                            ({
                                message: MyData.ERROR_MSG,
                                messageClass: 'field-validation-error'
                            })
                    }
                    else {
                        this.setState
                            ({
                                message: MyData.ERROR_MSG,
                                messageClass: 'field-validation-success'
                            })
                    }
                }
            }
            else {
                if (res.data[0].FLAG == "F") {
                    this.setState
                        ({
                            message: res.data[0].MESSAGE,
                            messageClass: 'field-validation-error'
                        })
                }
                else {
                    this.setState
                        ({
                            message: res.data[0].MESSAGE,
                            messageClass: 'field-validation-success'
                        })
                }
                var eGridDiv = document.querySelector('#myGrid');
                new agGrid.Grid(eGridDiv, GridInitializer(DynamiColDef("setting", "import", this.state.value), res.data));
            }
            this.setState.value = '0';
            this.setState.selectedFile = null;

        })
        event.preventDefault();
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
                                    <span className="dwn"><a href={this.state.downloadPath} download>Download Csv Format</a></span>
                                </div>
                            </li>
                            <li>
                                <label className="col-lg-2 col-xs-12 col-sm-2"></label>
                                <div className="col-lg-10 col-xs-12 col-sm-10 col-md-10">
                                    <button type="submit" id="upload" className="btn btn-info"><span className="hide"><i className="fa fa-spinner"></i></span> Upload</button>
                                </div>
                            </li>
                        </ul>
                    </form>
                    <div className="custom-error" id="custom-error"><span className={this.state.messageClass}>{this.state.message}</span></div>
                    <hr />
                    <div id="myGrid" className="ag-theme-balham" style={{ height: '300px', width: '100%', padding: '15px' }}></div>
                </div>
            </div>
        );
    }
}
//Render react component into the page
ReactDOM.render(<ImportForm urlPost="/Auth/Login" />, document.getElementById('import-base'));