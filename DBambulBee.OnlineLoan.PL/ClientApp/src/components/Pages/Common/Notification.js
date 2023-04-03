import React from 'react'


export default function Notification(props) {

    const { notify, setNotify } = props;

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }
        notify.isOpen = false;
    }

  return (
        <div id="toastsContainerTopRigh" className="toasts-top-right fixed">
            <div className={`toast ${notify.type} ${notify.isOpen}`}  role="alert" aria-live="assertive" aria-atomic="true">
                <div className="toast-header">
                    <button data-dismiss="toast" type="button" className="ml-2 mb-1 close" aria-label="Close" onClick={handleClose}>
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div className="toast-body">{ notify.message}</div>
            </div>
        </div> 
  )
}
