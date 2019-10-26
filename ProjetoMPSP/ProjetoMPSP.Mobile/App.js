import React from 'react';
import { View , Image , Text } from 'react-native';

import Buscador from './Components/Buscador/Buscador';
import styles from './assets/styles/styles'




export default function App() {
  return (
    <View style={styles.container}>
      <Header/>
      <Buscador/>
    </View>
  );
}

export class Header extends React.Component{
    render(){
      return(
        <View style={styles.header}>
          <Text>ProjetoMPSP</Text>
          <Image style={styles.LogoFiap} source={{uri: 'https://upload.wikimedia.org/wikipedia/commons/d/d4/Fiap-logo-novo.jpg'}}
        />
        </View>
      )
    }
}