import React, {Component, useEffect, useState} from "react";
import { Navigate, useParams} from 'react-router-dom';
import AuthUser from "../Services/AuthUser";
import { useNavigate } from 'react-router-dom';
import axios from "axios";
import EventEditModal from "../Components/Events/EventEditModal";
import EventCreateModal from "../Components/Events/EventCreateModal";


const AllEvents = () =>{

    let { id1 } = useParams();
    const navigate = useNavigate();
    const { http, getUser, getToken } = AuthUser();
    const [Event, setEvent] = useState("");      
    const[events, setEvents] = useState([]);
    
    useEffect(() =>{
        fetchEvents();
    } , []);

    const fetchEvents = () =>{
        axios.get(`http://localhost:5001/api/eventType/${id1}/event`)
        .then((res) => {
            //console.log(res);
            setEvents(res.data);
        })
        .catch((err) => {
            console.log(err);
        });
    };

    let ViewEvent = (id2) =>{
        console.log("view event for id:", id2);
        navigate(`${id2}`)

    }

    let CreateEvent = async () =>{
        console.log("create new event ");
        navigate(`event`)
    }

    let EditEvent = async (id) =>{
        console.log("edit event with id", id);
        navigate(`event/${id}`)
    }

    let RemoveEvent = (id) =>{
        console.log("remove event with id", id);
        http.delete(`eventType/${id1}/event/${id}`,{
            headers:{
                "Content-type": "application/json",
                "Authorization": `Bearer ${getToken()}`
            },
        }).then((res) => {
            console.log(res.data);
            window.location.reload(false);
             
        }).catch((error) => {
            alert("Cant delete event");
            navigate(`/home/eventType/${id1}/event`);
        })
 
    }

    return(
        <div>
            <br></br>
                <h2>All events</h2>
            <br></br>
            {getUser() != null ?(
                <div className="item-container">
                    <EventCreateModal id1={id1}/>
                </div>
            ): null}
            <br></br>
            <div className="item-container">
                {events.map((event) => (
                              <div className='card' key={event.id}>
                                <img src={event.pictureLink} alt=""   onError={({ currentTarget }) => {currentTarget.onerror = null; currentTarget.src="https://t4.ftcdn.net/jpg/00/89/55/15/360_F_89551596_LdHAZRwz3i4EM4J0NHNHy2hEUYDfXc0j.jpg";}}></img>
                                <h3>{event.name}</h3>
                                <br></br>
                                <button onClick={ () => ViewEvent(event.id)}  className="btn btn-info">More about {event.name}</button>
                                <br></br>
                                {getUser() != null && getUser().id == Event.UserId ?(
                                <EventEditModal id1={id1} id2={event.id} />/*<button onClick={ () => EditEvent(event.id)}  className="btn btn-dark">Edit</button>*/
                                ) : null}
                                <br></br>
                                {getUser() != null && getUser().id == Event.UserId ?(
                                <button onClick={ () => RemoveEvent(event.id)}  className="btn btn-danger">Remove</button>
                                ) : null}
                                <br></br>
                              </div>
                ))}
            </div>
        </div>
    );
}
export default AllEvents;

export class Events extends Component{
    render(){
        return(
            <div>
                <AllEvents></AllEvents>
            </div>
        )
    }
}