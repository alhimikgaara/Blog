import React from 'react'
import PropTypes from 'prop-types'
import { Button } from 'react-bootstrap';


class Details extends React.Component {
	 render() {
        return (<div>
    		<Button bsStyle="primary">{this.props.data}</Button>
    	</div>)
    }
}


Details.propTypes = {
	data: PropTypes.string
};
Details.defaultProps = {
	data: {}
};

export default Details;