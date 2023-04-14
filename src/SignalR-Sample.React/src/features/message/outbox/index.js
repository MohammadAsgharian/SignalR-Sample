import React, { useState, useEffect } from 'react';
import {
  FormControl,
  Select,
  MenuItem,
  Button,
  Grid,
} from '@mui/material';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';
import { PersonRepository } from '../../person/person-repository';
import { MessageRepository } from '../message-repository';


const SendMessage = () => {

  const [selectedPerson, setSelectedPerson] = useState('');
  const [persons, setPersons] = useState([]);
  const [message, setMessage] = useState('');

  useEffect(()=>{
    const fetchPersons = async () => {
      try {
        const persons = await PersonRepository.getAllPersons();
        setPersons(persons); // Set the list of persons in state

        } catch (error) {
        console.error("Error fetching persons: ", error);
      }
    };
    fetchPersons();
  },[]);



  const handlePersonChange = (event) => {
    setSelectedPerson(event.target.value);
  };

  const handleSendMessage = async () => {
    console.log(`Sending message "${message}" to ${selectedPerson}`);
    // Send the message to the selected person here
    try {
      const result =await  MessageRepository.createMessage(selectedPerson,message);
    } catch (error) {
      console.error("Login error: ", error);
    }
  };

  const handleQuillChange = (value) => {
    setMessage(value);
  };

  return (
      <Grid container padding={1} spacing={2} alignItems="center">
        <Grid item xs={12} sm={6}>
          <FormControl  fullWidth>
            <Select
              labelId="person-label"
              id="person-select"
              value={selectedPerson}
              onChange={handlePersonChange}
            > 
              {persons.map(person => (
              <MenuItem key={person.id} value={person.id}>
                {person.name}
              </MenuItem>
            ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item xs={12}>
          <ReactQuill value={message} onChange={handleQuillChange} />
        </Grid>
        <Grid item xs={12}>
          <Button
            variant="contained"
            color="primary"
            onClick={handleSendMessage}
          >
            Send Message
          </Button>
        </Grid>
      </Grid>
  );
};

export default SendMessage;
