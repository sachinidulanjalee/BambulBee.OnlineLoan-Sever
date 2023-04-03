import React from "react";

export const FormErrors = ({formErrors}) =>
  <span className='error invalid-feedback FormErrors' style={{display: "inline"}}>
     <p>{formErrors} </p>
  </span>