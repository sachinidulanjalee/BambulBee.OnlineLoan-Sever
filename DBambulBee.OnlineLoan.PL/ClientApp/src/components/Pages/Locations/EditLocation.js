import React, { Component, useState } from "react";
import { FormErrors } from '../Common/FormErrors';


export default class EditLocation extends Component {
	constructor(props) {
		super(props);
		this.onSubmit = this.onSubmit.bind(this);
		this.resetInputField = this.resetInputField.bind(this);

		this.state = {
			inputFieldValues: { txtLocationID:'', txtSubClassificationID:'',  txtClassificationID: '', txtDescription: ''},
			formErrorsMsg: { locationID: '', SubClassificationID: '', ClassificationID: '', Description: '' },
			isvalid: { LocationID: false, SubClassificationID:false, ClassificationID: false, Description: false },
			formValid: false,
			show: false
		}
	}

	handleUserInput(e) {
		const name = e.target.name;
		const value = e.target.value;
		this.setState({ [name]: {value } }, this.validateField(name, value) );
	}

	validateField(fieldName, value) {
		let fieldValidationErrors = this.state.formErrorsMsg;
		let isvalidField = this.state.isvalid;

		switch (fieldName) {
			
			case 'txtSubClassificationID':
				isvalidField.SubClassificationID = value.length != 0;
				fieldValidationErrors.SubClassificationID = isvalidField.SubClassificationID ? '' : 'Please Enter SubClassification ID';
				if (isvalidField.SubClassificationID) {
					isvalidField.SubClassificationID = value.match(/^([1-9]\d*)$/);
					fieldValidationErrors.SubClassificationID = isvalidField.SubClassificationID ? '' : 'SubClassification ID should be Number and canot be 0';
				}
				break;
			case 'txtClassificationID':
				isvalidField.ClassificationID = value.length != 0;
				fieldValidationErrors.ClassificationID = isvalidField.ClassificationID ? '' : 'Please Enter Classification ID';
				if (isvalidField.ClassificationID) {
					isvalidField.ClassificationID = value.match(/^([1-9]\d*)$/);
					fieldValidationErrors.ClassificationID = isvalidField.ClassificationID ? '' : 'Classification ID should be Number and canot be 0';
				}
				break;
			case 'txtDescription':
				isvalidField.Description = value.length != 0;
				fieldValidationErrors.Description = isvalidField.Description ? '' : 'Please Enter a valid Description';
				break;
			
			default:
				break;
		}
		this.setState({
			formErrorsMsg: fieldValidationErrors,
			isvalid: isvalidField
		}, this.validateForm);
	}

	validateForm() {
		this.setState({ formValid: this.state.isvalid.LocationID && this.state.isvalid.SubClassificationID && this.state.isvalid.ClassificationID && this.state.isvalid.Description });
	}

	onSubmit(e) {
		e.preventDefault();

	
		const obj = {
			LocationID: this.props.obj.locationID,
			SubClassificationID: this.props.obj.subClassificationID,
			ClassificationID: this.props.obj.classificationID,
			Description: this.props.obj.description,
			CreatedDateTime: this.props.obj.createdDateTime,
			CreatedBy: this.props.obj.createdBy,
			CreatedMachine: this.props.obj.createdMachine,
			ModifiedDateTime: new Date(),
			ModifiedBy: "bb",
			ModifiedMachine: "localhost"
		};

		fetch("https://localhost:44365/api/Locations/Edit", {
			method: "POST",
			headers: {
				'content-type': 'application/json'
			},
			body: JSON.stringify(obj)
		})
			.then(res => res.json())
			.then(result => {

				if (result) {
					alert("Edit Successful.");

				}
				else {
					alert("Edit Failed.");
				}

			},
				(error) => {
					alert('Server Error' + error);
				}
			);

	}

	resetInputField = () => {
		this.setState({
			inputFieldValues: { txtLocationID: '', txtSubClassificationID: '', txtClassificationID: '', txtDescription: '' },
			formErrorsMsg: { LocationID: '', SubClassificationID: '', ClassificationID: '', Description: '' },
			isvalid: { LocationID: false, SubClassificationID: false, ClassificationID: false, Description: false },
			formValid: false
		});
	}

	render() {
		
		return (
			<div>
				<div className="modal fade show" id="modal-lg" style={{ display: this.props.show, paddingRight: 16 }} aria-modal="true" role="dialog">
					<div className="modal-dialog modal-lg">
						<div className="modal-content">
							<div className="modal-header">
								<h4 className="modal-title">Edit Location</h4>
								<button type="button" className="close" data-dismiss="modal" aria-label="Close">
									<span aria-hidden="true">×</span>
								</button>
							</div>
							<form id="quickForm" onSubmit={this.onSubmit}>
								<div className="modal-body">
									<div className="form-group row">
										<label htmlFor="txtLocationID" className="col-sm-3 col-form-label">Location ID</label>
										<div className="col-sm-8">
											<input className="form-control" type="text" name="txtLocationID" placeholder="Location ID"
												value={this.props.obj.locationID} disabled min="1" maxLength="3" />
											<FormErrors formErrors={this.state.formErrorsMsg.LocationID} />
										</div>
									</div>
									<div className="form-group row">
										<label htmlFor="txtSubClassificationID" className="col-sm-3 col-form-label">Sub Classification ID</label>
										<div className="col-sm-8">
											<input className="form-control" type="text" name="txtSubClassificationID" placeholder="Sub Classification ID"
												value={this.props.obj.subClassificationID} disabled min="1" maxLength="3" />
											<FormErrors formErrors={this.state.formErrorsMsg.SubClassificationID} />
										</div>
									</div>
									<div className="form-group row">
										<label htmlFor="txtClassificationID" className="col-sm-3 col-form-label">Classification ID</label>
										<div className="col-sm-8">
											<input className="form-control" type="text" name="txtClassificationID" placeholder="Classification ID"
												value={this.props.obj.classificationID} disabled min="1" maxLength="3" />
											<FormErrors formErrors={this.state.formErrorsMsg.ClassificationID} />
										</div>
									</div>
									<div className="form-group row">
										<label htmlFor="txtDescription" className="col-sm-3 col-form-label">Description</label>
										<div className="col-sm-8">
											<input type="Text" name="txtDescription" placeholder="Description" className="form-control"
												defaultValue={this.props.obj.description} onChange={(event) => this.handleUserInput(event)} maxLength="150" />
											<FormErrors formErrors={this.state.formErrorsMsg.Description} />
										</div>
									</div>
									
								</div>
								<div className="modal-footer justify-content-end">
									<button type="submit" className="btn btn-success" >Add</button>
									<button type="reset" className="btn btn-danger" onClick={this.resetInputField}>Clear</button>
								</div>
							</form>
						</div>
					</div>
				</div>


			</div>
		)
	}
}