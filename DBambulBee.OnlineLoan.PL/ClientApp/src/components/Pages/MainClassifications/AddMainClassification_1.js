import React, { Component } from "react";
import { FormErrors } from '../Common/FormErrors';


export default class AddMainClassification extends Component {
	constructor(props) {
		super(props);
		this.onSubmit = this.onSubmit.bind(this);
		this.resetInputField = this.resetInputField.bind(this);

		this.state = {
			inputFieldValues : { txtClassificationID: '', txtDesEnglish: '', txtDesSinhala: '' },
			formErrorsMsg: { ClassificationID: '', DesEnglish: '', DesSinhala: '' },
			isvalid: { ClassificationID: false, DesEnglish: false, DesSinhala: false },
			formValid: false
		}

		const requestOptions = {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify({ title: 'React POST Request Example' })};
	}
	
	handleUserInput(e) {
		const name = e.target.name;
		const value = e.target.value;
		this.state.inputFieldValues = {name: value};
		this.validateField(name, value)
	}

	validateField(fieldName, value) {
		let fieldValidationErrors = this.state.formErrorsMsg;
		let isvalidField = this.state.isvalid;
		
		switch (fieldName) {
			case 'txtClassificationID':
				isvalidField.ClassificationID = value.length != 0;
				fieldValidationErrors.ClassificationID = isvalidField.ClassificationID ? '' : 'Please Enter Classification ID';
				if (isvalidField.ClassificationID) {
					isvalidField.ClassificationID = value.match(/^([1-9]\d*)$/);
					fieldValidationErrors.ClassificationID = isvalidField.ClassificationID ? '' : 'Classification ID should be Number and canot be 0';
				}
				break;
			case 'txtDesEnglish':
				isvalidField.DesEnglish = value.length != 0;
				fieldValidationErrors.DesEnglish = isvalidField.DesEnglish ? '' : 'Please Enter English Description';
				break;
			case 'txtDesSinhala':
				isvalidField.DesSinhala = value.length != 0;
				fieldValidationErrors.DesSinhala = isvalidField.DesSinhala ? '' : 'Please Enter Sinhala Description';
				break;
			default:
				break;
		}
		this.setState({
			formErrorsMsg : fieldValidationErrors,
			isvalid : isvalidField
		}, this.validateForm);
	}

	validateForm() {
		this.setState({ formValid: this.state.isvalid.ClassificationID && this.state.isvalid.DesEnglish && this.state.isvalid.DesSinhala });
	}

	onSubmit(e) {
		e.preventDefault();

		alert(this.state.inputFieldValues.txtDescriptionEnglish);
		const obj = {
			ClassificationID: Number(this.state.inputFieldValues.txtClassificationID),
			DescriptionEnglish: this.state.inputFieldValues.txtDescriptionEnglish,
			DescriptionSinhala: this.state.inputFieldValues.txtDescriptionSinhala,
			CreatedDateTime: new Date(),
			CreatedBy: "aa",
			CreatedMachine: 'localhost',
			ModifiedDateTime: new Date(),
			ModifiedBy: "bb",
			ModifiedMachine: "localhost"
		};

		fetch("https://localhost:44365/api/MainClassifications/Add", {
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

	resetInputField= () => {
		this.setState({
			inputFieldValues : { txtClassificationID: '', txtDesEnglish: '', txtDesSinhala: '' },
			formErrorsMsg: { ClassificationID: '', DesEnglish: '', DesSinhala: '' },
			isvalid: { ClassificationID: false, DesEnglish: false, DesSinhala: false },
			formValid: false
		});
	}

	render() {
		return (
			<div>
				<form id="quickForm" onSubmit={this.onSubmit}>
					<div className="card-body">
						<div className="form-group row">
							<label htmlFor="txtClassificationID" className="col-sm-2 col-form-label">Classification ID</label>
							<div className="col-sm-6">
								<input className="form-control" type="text" name="txtClassificationID" placeholder="Classification ID"
									value={this.state.inputFieldValues.txtClassificationID} onChange={(event) => this.handleUserInput(event)} min="1" maxLength="3"/>
								<FormErrors formErrors={this.state.formErrorsMsg.ClassificationID}  />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="txtDesEnglish" className="col-sm-2 col-form-label">Description English</label>
							<div className="col-sm-6">
								<input type="Text" name="txtDesEnglish" placeholder="Description English" className="form-control"
									value={this.state.inputFieldValues.txtDesEnglish} onChange={(event) => this.handleUserInput(event)} maxLength="150" />
								<FormErrors formErrors={this.state.formErrorsMsg.DesEnglish}  />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="txtDesSinhala" className="col-sm-2 col-form-label">Description Sinhala</label>
							<div className="col-sm-6">
								<input type="Text" name="txtDesSinhala" placeholder="Description Sinhala" className="form-control"
									value={this.state.inputFieldValues.txtDesSinhala} onChange={(event) => this.handleUserInput(event)} maxLength="150" />
								<FormErrors formErrors={this.state.formErrorsMsg.DesSinhala}  />
							</div>
						</div>
					</div>
					<div className="row justify-content-center">
						<button type="submit" className="btn btn-success mr-1" disabled={!this.state.formValid}>Add</button>
						<button type="reset" className="btn btn-danger" onClick={this.resetInputField}>Clear</button>
					</div>
				</form>

			</div>
		)
	}
}