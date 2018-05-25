import React from 'react'
import PropTypes from 'prop-types'
import { Button } from 'react-bootstrap';


import Contacts from './Contacts.js';
import Details from './Details.js';

class ApplicationMain extends React.Component 
{
    render() 
    {
        const myElement = document.getElementById('MyJson');
        let result;
        let some;
        
        if(myElement != null)
        {
            some = JSON.parse(myElement.innerHTML)[0].World;
            result = some.map((element, i) => 
            {
                if(Object.keys(element).includes("Details"))
                {
                    return <div key={i}><Details data={element.Details}/></div>
                }
                if(Object.keys(element).includes("Contacts"))
                {
                    return <div key={i}><Contacts data={element.Contacts}/></div>
                }
            });
        }
        return (
            <div>
                {result}
            </div>
        );
    }
}
export default ApplicationMain;