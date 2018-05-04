import React from 'react'
import PropTypes from 'prop-types'
import { Button } from 'react-bootstrap';

const propTypes = {
	world: PropTypes.string.isRequired,
}

class HelloWorld extends React.Component {
    render() {
        return (<div>
    		<Button bsStyle="danger">Hello World Danger</Button>
    		<Button bsStyle="primary">Hello World Primary</Button>
    		<Button bsStyle="success">Hello World Success</Button>
    	</div>)
    }
}
export default HelloWorld;