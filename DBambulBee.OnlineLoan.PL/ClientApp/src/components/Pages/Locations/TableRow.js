import React, { Component } from 'react'

export default class TableRow extends Component {
  render() {
    return (
        <tr>
            <td>{this.props.obj.LocationID}</td>
            <td>{this.props.obj.SubclassificationID}</td>
            <td>{this.props.obj.ClassificationID}</td>
            <td>{this.props.obj.Description}</td>
            <td>
                    <button type="button" className="btn btn-primary btn-sm checkbox-toggle mr-3"><i className="far fa-edit" />
                    </button>
                    <button type="button" className="btn btn-danger btn-sm checkbox-toggle"><i className="far fa-trash-alt" />
                    </button>
            </td>
        </tr>
    )
  }
}