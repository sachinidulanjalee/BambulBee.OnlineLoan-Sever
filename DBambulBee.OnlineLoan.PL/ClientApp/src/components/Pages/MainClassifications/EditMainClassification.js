import React, { Component } from "react";
import { FormErrors } from '../Common/FormErrors';


export default class EditMainClassification extends Component {
	constructor(props) {
		super(props);
		this.onSubmit = this.onSubmit.bind(this);
		this.resetInputField = this.resetInputField.bind(this);

		this.state = {
			inputFieldValues : { txtClassificationID: '', txtDesEnglish: '', txtDesSinhala: '' },
			formErrorsMsg: { ClassificationID: '', DesEnglish: '', DesSinhala: '' },
			isvalid: { ClassificationID: false, DesEnglish: false, DesSinhala: false },
			formValid: false,
			show : false
		}
	}
	
	handleUserInput(e) {
		const name = e.target.name;
		const value = e.target.value;
		this.setState({ inputFieldValues :{[name]: value} },
			() => { this.validateField(name, value) });
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

		if(!this.setState.formValid)
		{
			alert("Invalid Input");
			return;
		}

		const model = {
			ClassificationId: this.state.inputFieldValues.txtClassificationID,
			DescriptionEnglish: this.state.inputFieldValues.txtDesEnglish,
			DescriptionSinhala: this.state.inputFieldValues.txtDesSinhala,
			CreatedDateTime: new Date(),
			CreatedBy: "aa",
			CreatedMachine: "localhost",
			ModifiedDateTime: new Date(),
			ModifiedBy: "bb",
			ModifiedMachine: "localhost"
		};

		fetch(process.env.REACT_APP_API+'customer',{
				method:"PUT",
				headers :{
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(model)
			})
			.then(res => res.json())
			.then(result => {
				alert(result);
				this.resetInputField();
			},
			(error) => {
				alert('Server Error');
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
                    <div className="modal fade show" id="modal-lg" style={{display: this.props.show, paddingRight: 16}} aria-modal="true" role="dialog">
                        <div className="modal-dialog modal-lg">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h4 className="modal-title">Edit Main Classification</h4>
                                    <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                    </button>
                                </div>
                                <form id="quickForm" onSubmit={this.onSubmit}>
                                    <div className="modal-body">
                                        <div className="form-group row">
                                            <label htmlFor="txtClassificationID" className="col-sm-3 col-form-label">Classification ID</label>
                                            <div className="col-sm-8">
                                                <input className="form-control" type="text" name="txtClassificationID" placeholder="Classification ID"
                                                    value={this.props.obj.classificationID} onChange={(event) => this.handleUserInput(event)} disabled min="1" maxLength="3"/>
                                                <FormErrors formErrors={this.state.formErrorsMsg.ClassificationID}  />
                                            </div>
                                        </div>
                                        <div className="form-group row">
                                            <label htmlFor="txtDesEnglish" className="col-sm-3 col-form-label">Description English</label>
                                            <div className="col-sm-8">
                                                <input type="Text" name="txtDesEnglish" placeholder="Description English" className="form-control"
                                                    defaultValue={this.props.obj.descriptionEnglish} onChange={(event) => this.handleUserInput(event)} maxLength="150" />
                                                <FormErrors formErrors={this.state.formErrorsMsg.DesEnglish}  />
                                            </div>
                                        </div>
                                        <div className="form-group row">
                                            <label htmlFor="txtDesSinhala" className="col-sm-3 col-form-label">Description Sinhala</label>
                                            <div className="col-sm-8">
                                                <input type="Text" name="txtDesSinhala" placeholder="Description Sinhala" className="form-control"
                                                    defaultValue={this.props.obj.descriptionSinhala} onChange={(event) => this.handleUserInput(event)} maxLength="150" />
                                                <FormErrors formErrors={this.state.formErrorsMsg.DesSinhala}  />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="modal-footer justify-content-end">
                                        <button type="submit" className="btn btn-success" disabled={!this.state.formValid}>Add</button>
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