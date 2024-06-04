import React, { useEffect, useState  } from 'react';
import axios_api from '../../axios';


function Contact() {

    useEffect(() => {
        console.log("contact")
        
    })

    const getAllContacts = () => {
        axios_api.get("/Contacts").then((res) =>{
            console.log("res =>", res.data.result)
        }, (err) =>{
            console.log("err =>", err)
        })
    }

    const addContact = () =>{
        const contact = {
            email: "test100@email.com",
            firstName: "test f name",
            lastName: "test last name",
            phoneNumber: "1234567898"
        }
        axios_api.post("/Contacts", contact).then((res) =>{
            console.log("post res =>", res.data.result)
        }, (err) =>{
            console.log("err =>", err)
        })
    }
  return (
    <>
        <div>Contact</div>
        <button onClick={addContact}>Add Contact</button>
        <button onClick={getAllContacts}>Get All Contacts</button>
        <button>Get Contact By Id = 3</button>
    </>
  )
}

export default Contact