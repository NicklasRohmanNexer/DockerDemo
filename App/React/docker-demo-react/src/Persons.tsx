import React, { useState, useEffect } from "react";
import axios from "axios";

interface PersonDto {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
}

const Persons: React.FC = () => {
  const [persons, setPersons] = useState<PersonDto[]>([]);

  useEffect(() => {
    const fetchPersons = async () => {
      try {
        const response = await axios.get(
          "http://localhost:23223/Person/getAllPersons"
        );
        setPersons(response.data);
      } catch (error) {
        console.error("Error fetching persons:", error);
      }
    };

    fetchPersons();
  }, []);

  return (
    <div>
      <h1>Personer</h1>
      <ul>
        {persons.map((person) => (
          <li key={person.id}>
            {person.firstName} {person.lastName} - Age: {person.age}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Persons;
