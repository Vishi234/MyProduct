var MyInput = React.createClass({
    //onchange event
    handleChange: function (e) {
        this.props.onChange(e.target.value);
        var isValidField = this.isValid(e.target);
    },
    //validation function
    isValid: function (input) {
        //check required field
        if (input.getAttribute('required') != null && input.value === "") {
            input.classList.add('input-validation-error'); //add class error
            input.nextSibling.classList.add('field-validation-error');
            input.nextSibling.textContent = this.props.messageRequired; // show error message
            return false;
        }
        else {
            input.classList.remove('input-validation-error');
            input.nextSibling.classList.remove('field-validation-error');
            input.nextSibling.textContent = "";
        }
        //check data type // here I will show you email validation // we can add more and will later
        if (input.getAttribute('type') == "email" && input.value != "") {
            if (!this.validateEmail(input.value)) {
                input.classList.add('input-validation-error');
                input.nextSibling.classList.add('field-validation-error');
                input.nextSibling.textContent = this.props.messageEmail;
                return false;
            }
            else {
                input.classList.remove('input-validation-error');
                input.nextSibling.classList.remove('field-validation-error');
                input.nextSibling.textContent = "";
            }
        }
    },
    //email validation function
    validateEmail: function (value) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(value);
    },
    componentDidMount: function () {
        if (this.props.onComponentMounted) {
            this.props.onComponentMounted(this); //register this input in the form
        }
    },
    render: function () {
        var inputField;
        if (this.props.type == 'textarea') {
            inputField = <textarea value={this.props.value} ref={this.props.name} name={this.props.name}
                className='form-control' required={this.props.isrequired} onChange={this.handleChange} />
        }
        else {
            inputField = <input type={this.props.type} value={this.props.value} ref={this.props.name} name={this.props.name}
                className='form-control' required={this.props.isrequired} onChange={this.handleChange} />
        }
        return (
            <div className="form-group">
                <label htmlFor={this.props.htmlFor}>{this.props.label}:</label>
                {inputField}
                <span className="field-validation-error"></span>
            </div>
        );
    }
})
var LoginForm = React.createClass({
    getInitialState: function () {
        return {
            Email: '',
            Password: '',
            Fields: [],
            ServerMessage: ''
        }
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var validForm = true;
        this.state.Fields.forEach(function (field) {
            if (typeof field.isValid === "function") {
                var validField = field.isValid(field.refs[field.props.name]);
                validForm = validForm && validField;
            }
        });
        //after validation complete post to server 
        if (validForm) {
            var d = {
                email: this.state.Email,
                password: this.state.Password
            }
            $.ajax({
                type: "POST",
                url: this.props.urlPost,
                data: d,
                success: function (data) {
                    //Will clear form here
                    this.setState({
                        Fullname: '',
                        Email: '',
                        Message: '',
                        ServerMessage: data.message
                    });
                }.bind(this),
                error: function (e) {
                    console.log(e);
                    alert('Error! Please try again');
                }
            })
        }
    },
    onChangeEmail: function (value) {
        this.setState({
            Email: value
        });
    },
    onChangePassword: function (value) {
        this.setState({
            Password: value
        });
    },
    //register input controls
    register: function (field) {
        var s = this.state.Fields;
        s.push(field);
        this.setState({
            Fields: s
        })
    },
    render: function () {
        //Render form 
        return (
             <div>
                <div className="lgnttl">
                    <h2>Welcome</h2>
                    <p>Please enter your Email ID or Password to proceed</p>
                </div>
                <div className="login-base slideInDown">
                    <div className="tpara">
                        <span className="pull-left">LOGIN</span>
                        <span className="pull-right">Not registered yet? <a href="javascript:void(0)">SIGNUP</a></span>
                    </div>
                    <div className="login-form cstform">
                        <form name="loginForm" noValidate onSubmit={this.handleSubmit}>
                            <div className="form-group">
                                <MyInput type={'email'} value={this.state.Email} label={'Email Address'} name={'Email'} htmlFor={'Email'} isrequired={true}
                                    onChange={this.onChangeEmail} className="form-control col-md-12" onComponentMounted={this.register} messageRequired={'Email Required'} messageEmail={'Invalid Email'} />
                            </div>
                            <div className="form-group">
                                <MyInput type={'password'} value={this.state.Password} label={'Password'} name={'Password'} htmlFor={'Password'} isrequired={true}
                                    onChange={this.onChangePassword} className="form-control col-md-12" onComponentMounted={this.register} messageRequired={'Password required'} />
                            </div>
                            <div className="form-group">
                                <label className="check pull-left">
                                    <span>Remeber me</span>
                                    <input type="checkbox" name="remember" />
                                    <span className="checkmark"></span>
                                </label>
                                <a href="javascript:void(0)" className="frgtPass pull-right">Forgot my password</a>
                            </div>
                            <div className="form-group">
                                <button type="submit" className="btn btn-success btnDisable col-md-12">Login</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
});
//Render react component into the page
ReactDOM.render(<LoginForm urlPost="/Auth/Login" />, document.getElementById('content'));
