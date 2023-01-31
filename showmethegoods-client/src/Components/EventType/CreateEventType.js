import React, {Component, useEffect, useState} from "react";
import { Link } from "react-router-dom";
import { Row, Form, Col, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import AuthUser from "../../Services/AuthUser";
import '../../App.css';

const EventTypeComp = () =>{

    const [name, setName] = useState('')
    const [description, setDescription] = useState('')

    const navigate = useNavigate();
    const { http, getUser, getToken } = AuthUser();

    const create = () => {
        //console.log("name", name);
        //console.log("description", description);

        const data = {
            name: name,
            description: description,
        }
        //console.log(data);
        //console.log(getToken());
        http.post('eventType/', data, {
            headers: {
                "Content-type": "application/json",
                "Authorization": `Bearer ${getToken()}`
            },
        }).then((res) => {
            navigate('/home');
            console.log(res.data);
        }).catch((error) => {
            alert("Cant create event type");
            navigate('/home');
        })
    }

    return(
        <div className="col-sm-4 offset-sm-4">
            <br></br>
            <h2>Create new Event Type</h2>
            <br></br>
            <label>Name</label>
            <input type = "text" defaultValue={name} onChange={(e)=>setName(e.target.value)} className="form-control" placeholder="Name"/>
            <br></br>
            <label>Description</label>
            <input type = "textarea" defaultValue={description} onChange={(e)=>setDescription(e.target.value)} className="form-control" placeholder="Description"/>
            <br></br>
            <button onClick={create} className="btn btn-primary">Create Event</button>
        </div>
    )
}

export class EventTypeComponent extends Component{
    render(){
        return(
                <EventTypeComp></EventTypeComp>
        )
    }
}