import React, { useState, useEffect } from 'react';
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Button,
  Grid,
} from '@mui/material';
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';


const SendMessage = () => {

  const [selectedPerson, setSelectedPerson] = useState('');
  const [message, setMessage] = useState('');

  const handlePersonChange = (event) => {
    setSelectedPerson(event.target.value);
  };

  const handleSendMessage = () => {
    console.log(`Sending message "${message}" to ${selectedPerson}`);
    // Send the message to the selected person here
  };

  const handleQuillChange = (value) => {
    setMessage(value);
  };

  return (
      <Grid container padding={1} spacing={2} alignItems="center">
        <Grid item xs={12} sm={6}>
          <FormControl  fullWidth>
            <InputLabel id="person-label">Select a person</InputLabel>
            <Select
              labelId="person-label"
              id="person-select"
              value={selectedPerson}
              onChange={handlePersonChange}
            >
              <MenuItem value="Alice">Alice</MenuItem>
              <MenuItem value="Bob">Bob</MenuItem>
              <MenuItem value="Charlie">Charlie</MenuItem>
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
