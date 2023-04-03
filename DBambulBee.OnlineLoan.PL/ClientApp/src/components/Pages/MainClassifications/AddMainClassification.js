import React, { Component } from "react";
import { FormErrors } from '../Common/FormErrors';
import Notification from "../Common/Notification";
import * as mainClassificationService from '../../Services/mainClassificationService';


export default class AddSubClassification extends Component {
	constructor(props) {
		super(props);
		this.onSubmit = this.onSubmit.bind(this);
		this.resetFrom = this.resetFrom.bind(this);

		this.state = {

			txtClassificationID   : { Text: '', ErrorMsg:'', isvalide :false },
			txtDescriptionEnglish : { Text: '', ErrorMsg:'',isvalide :false  },
			txtDescriptionSinhala : { Text: '', ErrorMsg:'',isvalide :false },
            notify : { isOpen: false, message: '', type: '' },
            setNotify : { isOpen: false, message: '', type: '' },

			formValid: false
		}
	}

	render() {
		return (
			<div>
				<form id="quickForm" onSubmit={this.onSubmit}>
					<div className="card-body">
						<div className="form-group row">
							<label htmlFor="lblClassificationID" className="col-sm-2 col-form-label">Classification ID</label>
							<div className="col-sm-6">
								<input type="Text" name="txtClassificationID" placeholder="Classification ID" className="form-control"
									value={this.state.txtClassificationID.Text} onChange={(event) => this.handleUserInput(event)} />
								<FormErrors formErrors={this.state.txtClassificationID.ErrorMsg} />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="lblDescriptionEnglish" className="col-sm-2 col-form-label">Description English</label>
							<div className="col-sm-6">
								<input type="Text" name="txtDescriptionEnglish" placeholder="Description English" className="form-control"
									value={this.state.txtDescriptionEnglish.Text} onChange={(event) => this.handleUserInput(event)} />
								<FormErrors formErrors={this.state.txtDescriptionEnglish.ErrorMsg} />
							</div>
						</div>
						<div className="form-group row">
							<label htmlFor="lblDescriptionSinhala" className="col-sm-2 col-form-label">Description Sinhala</label>
							<div className="col-sm-6">
								<input type="Text" name="txtDescriptionSinhala" placeholder="Description Sinhala" className="form-control"
									value={this.state.txtDescriptionSinhala.Text} onChange={(event) => this.handleUserInput(event)} />
								<FormErrors formErrors={this.state.txtDescriptionSinhala.ErrorMsg}  />
							</div>
						</div>
					</div>
					<div className="row justify-content-center">
						<button type="submit" className="btn btn-success mr-1" disabled={!this.state.formValid}>Add</button>
						<button type="reset" className="btn btn-danger" resetFrom={this.resetFrom}>Clear</button>
					</div>
				</form>

                <Notification notify={this.state.notify} setNotify={this.state.setNotify}/>

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
		let txtClassificationID = this.state.txtClassificationID;
		let txtDescriptionEnglish = this.state.txtDescriptionEnglish;
		let txtDescriptionSinhala = this.state.txtDescriptionSinhala;

		switch (fieldName) {
			case 'txtClassificationID':
				ValidationResult = this.validateController("MainClassification ID", value, 3, true);
				txtClassificationID.isvalide = ValidationResult.Validated;
				txtClassificationID.ErrorMsg = ValidationResult.Message;
				break;

			case 'txtDescriptionEnglish':
				ValidationResult = this.validateController("Description in English", value, 150, false );
				txtDescriptionEnglish.isvalide = ValidationResult.Validated; 
				txtDescriptionEnglish.ErrorMsg = ValidationResult.Message;
				break;

			case 'txtDescriptionSinhala':
				ValidationResult = this.validateController("Description in Sinhala", value, 150, false );
				txtDescriptionSinhala.isvalide = ValidationResult.Validated; 
				txtDescriptionSinhala.ErrorMsg = ValidationResult.Message;
				break;
		}

		this.setState({
			txtClassificationID: txtClassificationID,
			txtDescriptionEnglish: txtDescriptionEnglish,
			txtDescriptionSinhala: txtDescriptionSinhala,
			formValid:  this.state.txtClassificationID.isvalide &&  this.state.txtDescriptionEnglish.isvalide && this.state.txtDescriptionSinhala.isvalide
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

			ClassificationID: Number(this.state.txtClassificationID.Text),
			DescriptionEnglish: this.state.txtDescriptionEnglish.Text,
			DescriptionSinhala: this.state.txtDescriptionSinhala.Text,
			CreatedDateTime: new Date(),
			CreatedBy: "aa",
			CreatedMachine: 'localhost',
			ModifiedDateTime: new Date(),
			ModifiedBy: "bb",
			ModifiedMachine: "localhost"
		};

        const result = mainClassificationService.addMainClassifications(obj);
        this.setState({notify :{ isOpen: 'show', 
                                    message: 'aaaaa   sasasassa asasasas sadsd',
                                    type: 'bg-success' }}) 
        
	}

	resetFrom(){
		this.state = {
			txtClassificationID   : { Text: '', ErrorMsg:'', isvalide :false },
			txtDescriptionEnglish : { Text: '', ErrorMsg:'',isvalide :false  },
			txtDescriptionSinhala : { Text: '', ErrorMsg:'',isvalide :false },
            notify : { isOpen: false, message: '', type: '' },
            setNotify : { isOpen: false, message: '', type: '' },

			formValid: false
		}
	}
}