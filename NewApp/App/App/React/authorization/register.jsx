var MyInput = React.createClass({
    //onchange event
    handleChange: function (e) {
        this.props.onChange(e.target.value);
        var isValidField = this.isValid(e.target);
    },
    //validation function
    isValid: function (input) {
        //check required field
        if (input.getAttribute("required") != null && input.value === "") {
            input.classList.add("input-validation-error"); //add class error
            input.previousSibling.classList.add("field-validation-error");
            input.previousSibling.textContent = this.props.messageRequired; // show error message
            return false;
        } else {
            input.classList.remove("input-validation-error");
            input.previousSibling.classList.remove("field-validation-error");
            input.previousSibling.textContent = "";
            return true;
        }
        //check data type // here I will show you email validation // we can add more and will later
        if (input.getAttribute("type") == "email" && input.value != "") {
            if (!this.validateEmail(input.value)) {
                input.classList.add("input-validation-error");
                input.previousSibling.classList.add("field-validation-error");
                input.previousSibling.textContent = this.props.messageEmail;
                return false;
            } else {
                input.classList.remove("input-validation-error");
                input.previousSibling.classList.remove("field-validation-error");
                input.previousSibling.textContent = "";
                return true;
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
        if (this.props.type == "textarea") {
            inputField = (
        <textarea value={this.props.value}
                  ref={this.props.name}
                  name={this.props.name}
                  className="form-control"
                  required={this.props.isrequired}
                  onChange={this.handleChange} />
      );
        } else {
            inputField = (
        <input type={this.props.type}
               value={this.props.value}
               ref={this.props.name}
               name={this.props.name}
               className="form-control"
               required={this.props.isrequired}
               onChange={this.handleChange} />
      );
        }
        return (
      <div className="form-group">
        <label htmlFor={this.props.htmlFor}>{this.props.label}:</label>
        <span className="field-validation-error" />{inputField}
      </div>
    );
    }
});
var RegisterForm = React.createClass({
    getInitialState: function () {
        return {
            CompanyName: "",
            FullName: "",
            Email: "",
            MobileNo: "",
            Password: "",
            Fields: [],
            ServerMessage: ""
        };
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
                company: this.state.CompanyName,
                name: this.state.FullName,
                mobile: this.state.MobileNo,
                email: this.state.Email,
                password: this.state.Password
            };
            $.ajax({
                type: "POST",
                url: this.props.urlPost,
                data: d,
                beforeSend: function () {
                    $("#progress").show();
                },
                success: function (data) {
                    $("#progress").hide();
                    CallToast(data.ERROR_MSG, data.ERROR_FLAG);
                }.bind(this),
                error: function (e) {
                    console.log(e);
                    $("#progress").hide();
                    alert("Error! Please try again");
                }
            });
        }
    },
    onChangeCompany: function (value) {
        this.setState({
            CompanyName: value
        });
    },
    onChangeFullName: function (value) {
        this.setState({
            FullName: value
        });
    },
    onChangeMobileNo: function (value) {
        this.setState({
            MobileNo: value
        });
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
        });
    },
    render: function () {
        //Render form
        return (
      <div>
        <div className="rgbse">
          <div className="rgfrm pull-left">
            <div className="login-base slideInDown">
              <div className="tpara">
                <span className="pull-left">REGISTER</span>
                <span className="pull-right">
                    Already have an account?{" "}
                  <a href="javascript:void(0)">Login</a>
                </span>
              </div>
              <div className="login-form cstform">
                <form name="loginForm" noValidate onSubmit={this.handleSubmit}>
                  <div className="form-group">
                    <MyInput type={"text"}
                             value={this.state.CompanyName}
                             label={"Company Name"}
                             name={"CompanyName"}
                             htmlFor={"CompanyName"}
                             isrequired={true}
                             onChange={this.onChangeCompany}
                             className="form-control col-md-12"
                             onComponentMounted={this.register}
                             messageRequired={"*"} />
                  </div>
                  <div className="form-group">
                    <MyInput type={"email"}
                             value={this.state.Email}
                             label={"Email Address"}
                             name={"Email"}
                             htmlFor={"Email"}
                             isrequired={true}
                             onChange={this.onChangeEmail}
                             className="form-control col-md-12"
                             onComponentMounted={this.register}
                             messageRequired={"*"}
                             messageEmail={"Invalid"} />
                  </div>
                  <div className="form-group">
                    <MyInput type={"text"}
                             value={this.state.FullName}
                             label={"Full Name"}
                             name={"FullName"}
                             htmlFor={"FullName"}
                             isrequired={true}
                             onChange={this.onChangeFullName}
                             className="form-control col-md-12"
                             onComponentMounted={this.register}
                             messageRequired={"*"} />
                  </div>
                  <div className="form-group">
                    <MyInput type={"text"}
                             value={this.state.MobileNo}
                             label={"Mobile No."}
                             name={"MobileNo"}
                             htmlFor={"MobileNo"}
                             isrequired={true}
                             onChange={this.onChangeMobileNo}
                             className="form-control col-md-12"
                             onComponentMounted={this.register}
                             messageRequired={"*"} />
                  </div>
                  <div className="form-group">
                    <MyInput type={"password"}
                             value={this.state.Password}
                             label={"Password"}
                             name={"Password"}
                             htmlFor={"Password"}
                             isrequired={true}
                             onChange={this.onChangePassword}
                             className="form-control col-md-12"
                             onComponentMounted={this.register}
                             messageRequired={"*"} />
                  </div>
                  <div className="form-group">
                    <p>
                        By proceeding to create your account, you are agreeing to our
                     <a href="javascript:void(0)">Terms of Service</a> &
                     <a href="javascript:void(0)">Privacy Policy</a>.
                    </p>
                  </div>
                  <div className="form-group">
                    <button type="submit"
                            className="btn btn-success btnDisable col-md-12">
                        Login
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>
          <div className="rgdes pull-right">
            <div className="overlay" />
          </div>
        </div>
      </div>
    );
    }
});
ReactDOM.render(
  <RegisterForm urlPost="/Auth/Register" />,
  document.getElementById("register-base")
);
