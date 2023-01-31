import React, {Component, useEffect, useState} from "react";
import {Link} from "react-router-dom";
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import AuthUser from "../Services/AuthUser";
import { Navigate, useParams} from 'react-router-dom';
import Stack from 'react-bootstrap/Stack';
import '../App.css';
import { Table } from "react-bootstrap";
import { format } from 'date-fns'
import { Comments } from "./Comments";

const EventComp = () =>{

    const navigate = useNavigate();
    let { id1, id2 } = useParams();
    const { http, getUser, getToken } = AuthUser();
        
    const[event, setEvent] = useState([]);
    useEffect(() =>{
        fetchEventcateogories();
    } , []);

    const fetchEventcateogories = () =>{
        axios.get(`http://localhost:5001/api/eventType/${id1}/event/${id2}`)
        .then((res) => {
            console.log(res);
            setEvent(res.data);
            console.log(res.data)
        })
        .catch((err) => {
            console.log(err);
        });
    };

    let ViewComments = (id3) =>{
        <Comments/>
        console.log("view comments for id:", id3);
        navigate(`comments`)

    }


    return(
        <div>
            <Table striped size="sm">
            <tbody>
            <tr>
                <td>Name</td>
                <td>{event.name}</td>
            </tr>
            <tr>
                <td>Description</td>
                <td>{event.description}</td>
            </tr>
            <tr>
                <td>Place</td>
                <td>{event.place}</td>
            </tr>
            <tr>
                <td>Price</td>
                <td>{event.price}</td>
            </tr>
            <tr>
                <td>When</td>
                <td>{event.eventDate}</td>
            </tr>
            </tbody>
            
            </Table>

            <br></br>
            {/*<div className="col text-center">
                <button onClick={ () => ViewComments(event.id)}  className="btn btn-info centre">View comments</button>
    </div>*/}
            <Comments/>
     </div>
        
    );
};

export class Event extends Component{
    render(){
        return(
                <EventComp></EventComp>
        )
    }
}