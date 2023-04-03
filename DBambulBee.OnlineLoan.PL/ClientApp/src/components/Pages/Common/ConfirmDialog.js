import React from 'react'

export default function ConfirmDialog(props) {
    const{  confirmDialog} = props;
    return (
        <div >
            <div className={`modal fade ${confirmDialog.isShow}`} id="modal-ConfirmDialog" aria-modal="true" role="dialog">
                <div className="modal-dialog modal-md">
                    <div className="modal-content" >
                        <div className={`modal-header ${confirmDialog.color}`} >
                            <h6 className="modal-title">{confirmDialog.title}</h6>
                        </div>
                        <div className="modal-body">
                            <h6>{confirmDialog.subTitle}</h6>
                        </div>
                        <div className="modal-footer justify-content-end">
                            <button type="button" className="btn btn-danger" onClick={confirmDialog.onConfirm}>Yes</button>
                            <button type="button" className="btn btn-success"  data-dismiss="modal" >No</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
