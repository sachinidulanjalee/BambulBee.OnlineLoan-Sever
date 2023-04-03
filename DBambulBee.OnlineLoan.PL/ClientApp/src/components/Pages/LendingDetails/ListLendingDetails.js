import React, { Component } from "react";
import TableSearch from "../Common/TableSearch";

export default class ListListLendingDetails extends Component {
    constructor(props) {
        super(props);
        this.state = { LendingDetails: [], editModalShow: false, obj: []  };

    }

    refreshList() {


        fetch('https://localhost:44365/api/LendingDetails/GetAll', {
            method: "GET",
            headers: {
                'Accept': 'application / json',
                'content-type': 'application/json'
            },
        })
            .then(response => response.json())
            .then(data => {
                
                this.setState({ LendingDetails: data })
            })
            .catch(function (error) {
                alert(error);
            });
    }

    delete(MembershipID, BookID, LendedDate,ExpiryPeriod,Status,) {
        if (window.confirm("Are You Sure ?")) {
            fetch('https://localhost:44365/api/LendingDetails/DeleteByPram/' + MembershipID + '/' + BookID + '/' + LendedDate + '/'+ExpiryPeriod + '/' + Status, {
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
                <table id="tblLendingDetails" className="table table-bordered table-striped re">
                    <thead>
                        <tr>
                            <th>Membership </th>
                            <th>Book</th>
                            <th>Lended Date</th>
                            <th>Expiry Date</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.LendingDetails.map(row =>
                            <tr key={row.LendingID}>
                                <td>{row.LendingID}</td>
                                <td>{row.MembershipID}</td>
                                <td>{row.BookID}</td>
                                <td>{row.LendedDate}</td>
                                <td>{row.ExpiryDate}</td>
                                <td>{row.Status}</td>
                                <td>
                                    <button type="button" className="btn btn-primary btn-sm checkbox-toggle mr-3"
                                        data-toggle="modal" data-target="#modal-lg"
                                        onClick={() => this.setState({ obj: row })} >
                                        <i className="far fa-edit" />
                                    </button>
                                    <button type="button" className="btn btn-danger btn-sm checkbox-toggle" onClick={() => this.delete(row.LendingID, row.MembershipID, row.BookID)}>
                                        <i className="far fa-trash-alt" />
                                    </button>

                                    {/*<EditMainClassification show={this.state.editModalShow} obj={this.state.obj} />*/}
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