import { parseJSON } from "jquery";
import React, { Component } from "react";
import { FormErrors } from '../Common/FormErrors';


export default class AddLendingDetails extends Component {
	constructor(props) {
		super(props);
		this.onSubmit = this.onSubmit.bind(this);
		this.resetFrom = this.resetFrom.bind(this);

		this.state = {

			txtMembershipID   : { Text: '', ErrorMsg:'' },
			txtBookID : { Text: '', ErrorMsg:'' },
			txtLendedDate : { Date: '', ErrorMsg:'' },
			txtExpiryPeriod : { Text: '', ErrorMsg:'' },
			txtCollectedDate : { Date: '', ErrorMsg:'' },
			ddlStatus : { Dropdown: '', ErrorMsg:'' },
			formValid: false
		}
	}

	render() {
		return (
			<div>
				<form id="quickForm" onSubmit={this.onSubmit}>
					<div className="card-body">
						<div className="form-group row">
							<label htmlFor="lblMembershipID" className="col-sm-2 col-form-label">Membership ID</label>
							<div className="col-sm-6">
								<input type="Text" name="txtMembershipID" placeholder="Membership ID" className="form-control"
									value={this.state.txtMembershipID.Text} onChange={(event) => this.handleUserInput(event)} />
								<FormErrors formErrors={this.state.txtMembershipID.ErrorMsg} />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="lbltxtBookID" className="col-sm-2 col-form-label">Book ID</label>
							<div className="col-sm-6">
								<input type="Text" name="txtBookID" placeholder="Book ID" className="form-control"
									value={this.state.txtBookID.Text} onChange={(event) => this.handleUserInput(event)} />
								<FormErrors formErrors={this.state.txtBookID.ErrorMsg} />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="lbltxtLendedDate" className="col-sm-2 col-form-label">Lended Date</label>
							<div className="col-sm-6">
								<input type="date" name="txtLendedDate" placeholder="Lended Date" className="form-control" value={this.state.txtLendedDate.Text} onChange={(event) => this.handleUserInput(event)}  InputLabelProps={{shrink: true, }}/>
								<FormErrors formErrors={this.state.txtLendedDate.ErrorMsg} />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="lbltxtExpiryPeriod" className="col-sm-2 col-form-label">Expiry Period</label>
							<div className="col-sm-6">
								<input type="Text" name="txtExpiryPeriod" placeholder="Expiry Period" className="form-control"
									value={this.state.txtExpiryPeriod.Text} onChange={(event) => this.handleUserInput(event)} />
								<FormErrors formErrors={this.state.txtExpiryPeriod.ErrorMsg} />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="lbltxtCollectedDate" className="col-sm-2 col-form-label">Lended Date</label>
							<div className="col-sm-6">
								<input type="date" name="txtCollectedDate" placeholder="Lended Date" className="form-control" value={this.state.txtCollectedDate.Text} onChange={(event) => this.handleUserInput(event)}  InputLabelProps={{shrink: true, }}/>
								<FormErrors formErrors={this.state.txtCollectedDate.ErrorMsg} />
							</div>
						</div>
					<div className="form-group row">
						<label htmlFor="lblddlStatus" className="col-sm-2 col-form-label">Status</label>
							<div className="col-sm-6">
								<select className="form-control select2bs4" style={{width: 550}}>
                    				<option selected="selected">-select-</option>
                    				<option>0</option>
									<option>1</option>
									<option>2</option>
								</select>
								<FormErrors formErrors={this.state.ddlStatus.ErrorMsg} />
							</div>
					</div>
					</div>
					<div className="row justify-content-center">
						<button type="submit" className="btn btn-success mr-1" disabled={!this.state.formValid}>Add</button>
						<button type="reset" className="btn btn-danger" resetFrom={this.resetFrom}>Clear</button>
					</div>
				</form>

			</div>
		)
	}
	
	handleUserInput(e) {

		const name = e.target.name;
		const value = e.target.value;

		this.setState(currentState => ({ [name]: { ...currentState, Text: value } }), () => { this.validateField(name, value) });
	}

	validateField(fieldName, value) {

		var ValidationResult = "";
		let IsValidate = false;
		let txtMembershipID = this.state.txtMembershipID;
		let txtBookID = this.state.txtBookID;
		let txtLendedDate = this.state.txtLendedDate;
		let txtExpiryPeriod = this.state.txtExpiryPeriod;
		let txtCollectedDate = this.state.txtCollectedDate;
		let ddlStatus = this.state.ddlStatus;

		switch (fieldName) {
		
			case 'txtMembershipID':
				ValidationResult = this.validateController("Membership ID", value, 6, true);
				txtMembershipID.ErrorMsg = ValidationResult.Message;
				break;

			case 'txtBookID':
				ValidationResult = this.validateController("Book ID", value, 6, false );
				txtBookID.ErrorMsg = ValidationResult.Message;
				break;

			case 'txtLendedDate':
				ValidationResult = this.validateController("Lended Date", value, 10, false );
				txtLendedDate.ErrorMsg = ValidationResult.Message;
				break;

			case 'txtExpiryPeriod':
				ValidationResult = this.validateController("Expiry Period", value, 3, false );
				txtExpiryPeriod.ErrorMsg = ValidationResult.Message;
				break;
			
			case 'txtCollectedDate':
				ValidationResult = this.validateController("Collected Date", value, 10, false );
				txtCollectedDate.ErrorMsg = ValidationResult.Message;
				break;

			case 'ddlStatus':
				ValidationResult = this.validateController("Status",  false );
				ddlStatus.ErrorMsg = ValidationResult.Message;
				break;
		}

		this.setState({
			txtMembershipID: txtMembershipID,
			txtBookID: txtBookID,
			txtLendedDate:txtLendedDate,
			txtExpiryPeriod : txtExpiryPeriod,
			txtCollectedDate:txtCollectedDate,
			ddlStatus : ddlStatus,
			formValid: this.state.txtMembershipID.ErrorMsg == '' && this.state.txtBookID.ErrorMsg == '' && this.state.txtLendedDate.ErrorMsg =='' && this.state.txtExpiryPeriod.ErrorMsg == '' && this.state.txtCollectedDate.ErrorMsg == '' && this.state.ddlStatus.ErrorMsg ==''
		});
	}
	validateController(controllerName, value, maxLength, IsNumbersOnly) {

		let validated = true;
		let Message = '';

		validated = (value != "0");
		Message = validated ? '' : controllerName + ' canot be 0';

		if (validated) {

			validated = value.length != 0;
			Message = validated ? '' : controllerName + ' Can not be blank';
		}

		if (validated) {

			validated = value.length <= maxLength;
			Message = validated ? '' : 'Maximum number of length is ' + maxLength;
		}

		if (validated && IsNumbersOnly) {
			validated = value.match(/^(0|[1-9]\d*)$/);
			Message = validated ? '' : controllerName + ' should be Numbers only.';
		}

		return  { "Message": Message, "Validated": validated };

	}

	onSubmit(e) {
		e.preventDefault();

		const obj = {

			MembershipID: Number(this.state.txtMembershipID.Text),
			BookID: Number(this.state.txtBookID.Text),
			LendedDate: this.state.txtLendedDate.Date,
			ExpiryPeriod : Number(this.state.txtExpiryPeriod.Text),
			CollectedDate : this.state.txtCollectedDate.Date,
			Status : this.state.ddlStatus.Dropdown,
			CreatedDateTime: new Date(),
			CreatedBy: "aa",
			CreatedMachine: 'localhost',
			ModifiedDateTime: new Date(),
			ModifiedBy: "bb",
			ModifiedMachine: "localhost"
		};

			fetch("https://localhost:44365/api/LendingDetails/Add", {
				method: "POST",
				headers: {
					'content-type': 'application/json'
				},
				body: JSON.stringify(obj)
			})
			.then(res => res.json())
			.then(result => {

				if (result ) {
					alert("insert Successful.");
				}
				else {
					alert("insert Failed.");
				}

			},
			(error) => {
				alert('Server Error' + error);
			}
		);
	}

	resetFrom(){
		this.setState({
			txtMembershipID: '',
			txtBookID: '',
			txtLendedDate:'',
			txtExpiryPeriod:'',
			txtCollectedDate:'',
			ddlStatus:'',
			ErrorMessages: {txtMembershipID: '', BookID: '',LendedDate:'',txtExpiryPeriod:'',txtCollectedDate:'',ddlStatus:'' },
		
		});
	}
}