import React, { Component } from "react";
import TableSearch from "../Common/TableSearch";
import EditLocation from "./EditLocation";

export default class ListLocations extends Component {
    constructor(props) {
        super(props);
        this.state = { location: [], editModalShow: false, obj: []  };

        
    }

    refreshList() {


        fetch('https://localhost:44365/api/Locations/GetAll', {
            method: "GET",
            headers: {
                'Accept': 'application / json',
                'content-type': 'application/json'
            },
        })
            .then(response => response.json())
            .then(data => {
                
                this.setState({ location: data })
            })
            .catch(function (error) {
                alert(error);
            });
    }

    delete(LocationID, SubClassificationID, ClassificationID) {
        if (window.confirm("Are You Sure ?")) {
            fetch('https://localhost:44365/api/Locations/DeleteByPram/' + LocationID + '/' + SubClassificationID + '/' + ClassificationID, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
        this.refreshList();
    }

    
    componentDidMount() {
        this.refreshList();
    }

    test(event) {

        alert(event);
    }

    render() {
        return (
            <div>
                <TableSearch Greeting="Hi" />
                <table id="tblLocations" className="table table-bordered table-striped re">
                    <thead>
                        <tr>
                            <th>Location ID</th>
                            <th>SubClassification ID</th>
                            <th>Classification ID</th>
                            <th>Description</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.location.map(row =>
                            <tr key={row.locationID}>
                                <td>{row.locationID}</td>
                                <td>{row.subClassificationID}</td>
                                <td>{row.classificationID}</td>
                                <td>{row.description}</td>
                                <td>
                                    <button type="button" className="btn btn-primary btn-sm checkbox-toggle mr-3"
                                        data-toggle="modal" data-target="#modal-lg"
                                        onClick={() => this.setState({ obj: row })} >
                                        <i className="far fa-edit" />
                                    </button>
                                    <button type="button" className="btn btn-danger btn-sm checkbox-toggle" onClick={() => this.delete(row.locationID, row.subClassificationID, row.classificationID)}>
                                        <i className="far fa-trash-alt" />
                                    </button>

                                    <EditLocation show={this.state.editModalShow} obj={this.state.obj} />
                                </td>
                            </tr>)}
                    </tbody>
                    <tfoot>
                        <tr></tr>
                    </tfoot>
                </table>
            </div>

        );
    }
}