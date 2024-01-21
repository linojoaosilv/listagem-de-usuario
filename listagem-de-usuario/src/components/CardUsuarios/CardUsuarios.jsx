import React from "react";
import styles from "./CardUsuario.module.css";
import axios from "axios";

function CardUsuario({usuario}){

    async function RemoverUsuario(){
        const confirmacao = window.confirm(
          "Deseja remover o usuario?" + usuario.nome + "?"
        ); // o sistema pergunta ao usuario se ele realmente quer deletar o usuario
    
        if(!confirmacao){
          return;
        }; // verifica se a o usuario confirmou
    
        const response = await axios.delete(
          "https://localhost:44387/api/usuarios/deletar?id=" + usuario.id
        );
    
        if(response.status !== 200){
          alert("deu ruim!");
          return;
        }
        alert("Removido com sucesso!");
        window.location.reload();
      }

    return(
        <div className={styles.card}>
            <p>Nome: {usuario.nome}</p>
            <p>Email: {usuario.email}</p>
            <button onClick={RemoverUsuario}>Remover</button>
        </div>
    )
}

export default CardUsuario;

