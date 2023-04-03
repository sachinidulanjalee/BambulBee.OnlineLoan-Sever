import React, { Component } from 'react';
import { Container } from 'reactstrap';

import { Menu } from '../Includes/Menu';
import { Navbar } from '../Includes/Navbar';
import { Footer } from '../Includes/Footer';

export class MasterLayout extends Component {
    static displayName = MasterLayout.name;

  render () {
    return (
        <div>
            <Navbar />
            <Menu />
                {this.props.children}
            <Footer />
         </div>
    );
  }
}
