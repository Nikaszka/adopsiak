// import { reactive } from 'vue'
// export default reactive([
//     {id:0, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
//     {id:1, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
//     {id:2, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
//     {id:3, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
//     {id:4, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
//     {id:5, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
//     {id:6, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
//     {id:7, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
//     {id:8, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
//     {id:9, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
//     {id:10, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
//     {id:11, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
//     {id:12, name: "Gucio", breed: "Mieszaniec", gender: "samiec", age: "ok. 4 lata", location: "Kraków, ul. Pomorska", image: "/pies1.jpg", animal: "pies"},
//     {id:13, name: "Aldona", breed: "Kot syjamski", gender: "samica", age: "5 lat", location: "Balice", image: "/kot_syjamski.png", animal: "kot" },
//     {id:14, name: "Morał", breed: "Mieszaniec", gender: "samiec", age: "ok. 2 lata", location: "Kraków, Czyżyny", image: "/pies3.jpg", animal: "pies" },
//     {id:15, name: "Śnieżka", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" },
//     {id:16, name: "Azor", breed: "Labrador", gender: "samica", age: "1 rok", location: "Bibice", image: "/labrador.jpg", animal: "pies" }
// ])

import { reactive, onMounted } from 'vue'
export default {
    setup() {
      const animals = reactive([]);
  
      const fetchAnimals = async () => {
        try {
          const response = await fetch('https://localhost:7241/Animals');
          const data = await response.json();
          animals.splice(0, animals.length, ...data); // Replace existing data with fetched data
        } catch (error) {
          console.error('Error fetching animals:', error);
        }
      };
  
      onMounted(fetchAnimals); // Fetch animals when the component is mounted
  
      return {
        animals
      };
    }
  };



// const formData = ref({
//     firstName: '',
//     lastName: '',
//     emailAddress: '',
//     address: {
//       phoneNumber: '',
//       streetName: '',
//       buildingNumber: '',
//       apartmentNumber: '',
//       city: '',
//       voivodeship: '',
//       zipCode: ''
//     },
//     selectedAnimalId: 0,
//     firstQuestion: '',
//     secondQuestion: '',
//     thirdQuestion: ''
//   });
  
//   const submitForm = async () => {
//     try {
//       const response = await fetch('https://localhost:7241/AdoptionForms/add', {
//         method: 'POST',
//         headers: {
//           'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(formData.value)
//       });
  
//       const responseData = await response.json();
//       console.log('Response:', responseData);
//       // Optionally, do something with the response data
//     } catch (error) {
//       console.error('Error:', error);
//       // Optionally, handle errors
//     }
//   };