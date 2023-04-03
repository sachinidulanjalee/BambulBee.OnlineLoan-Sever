import React, { Component } from "react";
import TableSearch from "../Common/TableSearch";

export default class ListSubClassifications extends Component {
    constructor(props) {
        super(props);
        this.state = { classification: []  , xx :""};
        
    }

    refreshList() {
        fetch(process.env.REACT_APP_API + 'customer')
            .then(response => response.json())
            .then(data => {
                this.setState({ classification: data })
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    tabRow() {
        return this.state.classification.map(function (object, i) {
           /* return <TableRow obj={object} key={i} />*/
        });
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
                        {this.tabRow()}
                    </tbody>
                    <tfoot>
                        <tr></tr>
                    </tfoot>
                </table>
            </div>

        );
    }
}