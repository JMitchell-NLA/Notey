import React, { Component } from 'react';
import { Container,Row,Col,Jumbotron } from 'reactstrap';
import { NoteHolder } from './NoteHolder'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
      <NoteHolder/>
    </div>
    );
  }
}
