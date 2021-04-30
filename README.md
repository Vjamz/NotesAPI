# NotesAPI Exercise

I implented this API using .Net Core 3.1 and using entity framework core. The data is persistently stored in a sqlite db file that is within the project. Said db file 
should create when running the initial code.

For testing purposes, I used Postmate to send information to the API.

# GET
To get a full list of the notes: https://localhost:{port}/api/Notes 
Example result:

[
    {
        "id": 1,
        "notesName": "Test Notes",
        "note": "This is a test"
    },
    {
        "id": 2,
        "notesName": "Notes here",
        "note": "Test Number 2"
    }
]

# GET with ID
To get a specific note: https://localhost:{port}/api/Notes/1 

Example Result:
    {
        "id": 1,
        "notesName": "Test Notes",
        "note": "This is a test"
    }

# POST
To insert a note: https://localhost:{port}/api/Notes
Example data: 

  {
    "NotesName": "Test 3",
    "Note": "3rd Test"
  }
  
Example result: 

  {
    "id": 3
    "NotesName": "Test 3",
    "Note": "3rd Test"
  }
  
# PUT
To edit a note: https://localhost:{port}/api/Notes/2
Example data:
    {
        "id": 2,
        "notesName": "Editted Notes",
        "note": "Hey these notes are different!"
    }
Result: 
    {
        "id": 2,
        "notesName": "Editted Notes",
        "note": "Hey these notes are different!"
    }
    
# DELETE
To Delete a note: https://localhost:{port}/api/Notes/2
Results after should return NotFound error.
