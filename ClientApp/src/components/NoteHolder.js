import React, { Component } from 'react';
import { Container,Row,Col,Jumbotron,Button } from 'reactstrap';
import './NoteHolder.css'

export class NoteHolder extends Component {
  static displayName = NoteHolder.name;

  constructor(props) {
    super(props); // <- always call your constructors kids! 
    this.state = { notes: [], loading: true, value:"" }; // <- Check out my state yo'  

    this.handleInput = this.handleInput.bind(this);

    this.handleClick = this.handleClick.bind(this);

  } //              ^ Array to store notes  ^ Check the loading state


  // LIFECYCLE HOOK!! BABY!!! 
  componentDidMount() {
    this.getNotes();
  }


  handleInput(event){
    this.setState({value: event.target.value})
  }

  handleKeyPress = (event) => {
    if(event.key === 'Enter'){
      this.handleClick(event);
    }
  }

  handleClick(event){
    fetch('api/Note', {
      method: 'POST', // or 'PUT'
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({title:this.state.value,content:""}),
    })
.then((response) => response.json())
.then((data) => {
  console.log('Success:', data);
  this.setState({value:""});
  this.getNotes();
})
.catch((error) => {
  console.error('Error:', error);
});
}


  static renderNotes(notes) {
    return (
        <span>
        { // this is the start of an echo section.  Don't put HTML in here.
            notes.map( note => // This boi gonna render them all! 
                <div>
                <q>{note.title}</q>
                <br></br>    
                </div>           
        )
        }
        </span>
    );
  }



  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : NoteHolder.renderNotes(this.state.notes);
    // What a edgy return statement! :O 
    return ( // In line event handler!! 
      <output>
        <div>

        {contents}

        <q><input type="text" className="cardInput" onKeyPress={this.handleKeyPress} onClick={() => this.setState({value:""})} value={this.state.value} onChange={this.handleInput}></input></q>
        {/* <Button color="lin  k" onClick={this.handleClick}> click me! </Button> */}
        </div>
      </output>
    );
  }

  async getNotes() {
    const response = await fetch('api/Note');
    const data = await response.json();
    this.setState({ notes: data, loading: false });
  }

}

