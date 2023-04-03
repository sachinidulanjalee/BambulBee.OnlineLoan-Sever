import React, { Component,useState } from "react";
import EditMainClassification from "./EditMainClassification";
import TableSearch from "../Common/TableSearch";
import ConfirmDialog from "../Common/ConfirmDialog";
import * as mainClassificationService from "../../Services/mainClassificationService";

export default class ListMainClassification extends Component {
    constructor(props) {
        super(props);
        this.state = { 
            classification: [],
            editModalShow:'' , 
            obj: [],
            confirmDialog :{isShow:false,title:'',subTitle:'',color : ""},
            
        };

    } 
    

    refreshList() {
          fetch('https://localhost:44365/api/MainClassifications/GetAll')
             .then(response => response.json())
             .then(result => {
                if (result ) {
					this.setState({ classification: result })
                    
				}
				else {
					alert("No Records.");
				}

             })
             .catch(function (error) {
                alert('Server Error' + error);
             });
    }

    onDelete(id){
        
        //if(window.confirm("Are You Sure ?"))
            //{
                //mainClassificationService.deleteMainClassification(id);
                fetch('https://localhost:44365/api/MainClassifications/Delete/'+id)
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
            //}
        this.refreshList();
    }

    componentDidMount(){
        this.refreshList();
    }

    // componentDidUpdate(){
    //     this.refreshList();
    // }

    
    


    render() {
        return (
            <div>
                <TableSearch />
                <table id="tblMainClassification" className="table table-bordered table-striped re">
                    <thead>
                        <tr>
                            <th>ClassificationID</th>
                            <th>Description English</th>
                            <th>DescriptionSinhala</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    {this.state.classification.map(row => 
                            <tr key={row.classificationID}>
                                <td>{row.classificationID}</td>
                                <td>{row.descriptionEnglish}</td>
                                <td>{row.descriptionSinhala}</td>
                                <td>
                                    <button type="button" className="btn btn-outline-primary  btn-sm  mr-3"
                                    data-toggle="modal" data-target="#modal-lg"
                                    onClick={() => this.setState({ obj : row})} >
                                        <i className="far fa-edit" />
                                    </button>

                                    <button type="button" className="btn btn-outline-danger btn-sm "  data-toggle="modal" data-target="#modal-ConfirmDialog"
                                        onClick={() => this.setState({ confirmDialog : {
                                            isShow:'show',
                                            title:'Are you sure to delete this record ?',
                                            subTitle:'You can not undo this operation',
                                            color : "bg-danger",
                                            onConfirm: () => { this.onDelete(row.classificationID) }
                                        }
                                    })} >
                                        <i className="far fa-trash-alt" />
                                    </button>
                                    
                                    


                                </td>
                            </tr>)}
                    </tbody>
                    <tfoot>
                        <tr></tr>
                    </tfoot>
                </table>

                <EditMainClassification show={this.state.editModalShow} obj={this.state.obj} />
                <ConfirmDialog confirmDialog={this.state.confirmDialog} />
                
            </div>
            
        );

    }
}