import React from 'react'
import PropTypes from 'prop-types'
import { Button } from 'react-bootstrap';


class Contacts extends React.Component {
	 render() {
        return (<div>
    		<Button bsStyle="danger">{this.props.data}</Button>
    		<Button bsStyle="primary">Hello World Primary</Button>
    		<Button bsStyle="success">Hello World Success</Button>
    	</div>)
    }
}

Contacts.propTypes = {
	data: PropTypes.number
};
Contacts.defaultProps = {
	data: {}
};

export default Contacts;