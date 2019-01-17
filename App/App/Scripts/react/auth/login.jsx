class LoginBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            email: "",
            password: "",
            submitted: false,
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleFormSubmit = this.handleFormSubmit.bind(this);
        this.isValidationError = this.isValidationError.bind(this);
        this.flag = true;
        this.isFormValidationErrors = false;
    }
    handleChange(event) {
        let name = event.target;
        let value = event.target;
        this.setState({ [name]: value });
        let submitted = this.state;
    }
    isValidationError(flag) {
        this.isFormValidationErrors = flag;
    }
    handleFormSubmit(event) {
        event.preventDefault();
        this.setState({ submitted: true });
        let email, password = this.state;
        if (!this.isFormValidationErrors) {
            //you are ready to dispatch submit action here.
        }
    }
    render() {
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
                        <form noValidate onSubmit={this.handleFormSubmit}>
                        <div className="form-group">
                            <label htmlFor="email">Email address</label>
                            <input type="text" value={this.state.email} onChange={ this.handleChange } name="email" className="form-control col-md-12" />
                            <Validator isValidationError={this.isValidationError}
                                       isFormSubmitted={submitted}
                                       reference={this.state.email}
                                       validationRules={{required:true,number:true,maxLength:10}}
                                       validationMessages={{required:"This field is required",number:"Not a valid number",maxLength:"Not a valid number"}} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="password">Password</label>
                            <input type="password" value={ password } onChange={ this.handleChange } name="password" className="form-control col-md-12" />
                            <Validator isFormSubmitted={submitted}
                                       reference={password}
                                       validationRules={{required:true}}
                                       validationMessages={{required:"This field is required",}} />

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
                        <div className="orLabelBase">
                            <span className="orLabel">OR Login Using</span>
                            <hr />
                        </div>
                        <div className="form-group">
                            <ul className="social-login">
                                <li><a href="javascript:void(0)"><i className="fab fa-google-plus-square"></i></a></li>
                                <li><a href="javascript:void(0)"><i className="fab fa-facebook-square"></i></a></li>
                                <li><a href="javascript:void(0)"><i className="fab fa-twitter-square"></i></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        );

    }
}
ReactDOM.render(<LoginBox />, document.getElementById('content'));