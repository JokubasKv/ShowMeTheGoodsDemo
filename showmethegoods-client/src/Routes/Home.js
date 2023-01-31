import React, {Component} from "react";
import '../App.css';
import AllEventTypes from "./EventTypes";

export class Home extends Component{
    render(){
        return(
            <div>
                <AllEventTypes></AllEventTypes>
            </div>
        )
    }
}