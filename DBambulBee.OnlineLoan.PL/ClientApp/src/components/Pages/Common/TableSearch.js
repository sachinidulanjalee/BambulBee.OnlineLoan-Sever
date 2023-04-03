import React from 'react'

export default function () {
    return (
        <div>
            <div className="form-group row justify-content-end mt-2" style={{ marginRight: 0 }}>
                <div className="input-group input-group-sm" style={{ width: 200 }}>
                    <input type="text" name="txtTableSearch" className="form-control float-right" placeholder="Search" />
                    <div className="input-group-append">
                        <button type="button" className="btn btn-primary">
                            <i className="fas fa-search" />
                        </button>
                    </div>
                </div>
            </div>
        </div>
    )
}
