import React, {useEffect, useState} from "react";
import AuthUser from "../Services/AuthUser";
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import '../App.css';

import EventTypeCreateModal from "../Components/EventType/CreateEventTypeModal";
import EventTypeEditModal from "../Components/EventType/EditEventTypeModal";
//import eventType from "../Components/EventType";


const AllEventTypes = () =>{

    const navigate = useNavigate();
    const { http, getUser, getToken } = AuthUser();
    const [EventType, setPost] = useState("");

        
    const[eventTypes, setEventTypes] = useState([]);
    useEffect(() =>{
        fetchEventTypes();
    } , []);

    const fetchEventTypes = () =>{
        axios.get("http://localhost:5001/api/eventType")
        .then((res) => {
            //console.log(res);
            setEventTypes(res.data);
        })
        .catch((err) => {
            console.log(err);
        });
    };

    let ViewEvents = (id) =>{
        console.log("view Events for id:", id);
        navigate(`api/eventType/${id}/event`)

    }

    let EditEventType = async (id) =>{
        console.log("edit event type with id", id);
        navigate(`api/eventType/${id}`)
    }

    let CreateEventType = async () =>{
        console.log("create new event type");
        //navigate(`api/eventType/`)
    }

    let RemoveEventType = (id) =>{
        console.log("remove event type with id", id);
        http.delete(`/eventType/${id}`,{
            headers:{
                "Content-type": "application/json",
                "Authorization": `Bearer ${getToken()}`
            },
        }).then((res) => {
            console.log(res.data);
            window.location.reload(false);  
            navigate("/home");
        }).catch((error) => {
            alert("Cant delete Event category");
            navigate(`/home`);
        })

    }


    return(
        <div>
            <br></br>
            <h2>All Event categories</h2>
            <br></br>
            {getUser() != null ?(
                <div className="item-container">
                    <EventTypeCreateModal/>
                </div>
            ): null}
                <br></br>
            <div className="item-container">
                {eventTypes.map((eventType) => (
                              <div className='card' key={eventType.id}>
                                <img src={eventType.pictureLink} alt="" onError={({ currentTarget }) => {currentTarget.onerror = null; currentTarget.src="https://t4.ftcdn.net/jpg/00/89/55/15/360_F_89551596_LdHAZRwz3i4EM4J0NHNHy2hEUYDfXc0j.jpg";}}></img>
                                <h3>{eventType.name}</h3>
                                <p>{eventType.description}</p>
                                <br></br>
                                <button onClick={ () => ViewEvents(eventType.id)}  className="btn btn-info">View events</button>
                                <br></br>
                                {getUser() != null && getUser().id === EventType.UserId ?(
                                <EventTypeEditModal id={eventType.id}/>
                                /*<button onClick={ () => EditEventType(eventType.id)}  className="btn btn-dark">Edit</button>*/
                                ) : null}
                                <br></br>
                                {getUser() != null && getUser().id === EventType.UserId ?(
                                <button onClick={ () => RemoveEventType(eventType.id)}  className="btn btn-danger">Remove</button>
                                ) : null}
                              </div>
                ))}
            </div>
        </div>
        
        
    );
};

export default AllEventTypes;
