import React, { Component } from 'react';
import './style.css';
import { Table, Button, Form, FormGroup, Label, Input, Alert } from 'reactstrap';
import PubSub from 'pubsub-js';

class FormularioLocais extends Component {

  state = { 
    modelo: {
      localReciclagemId: 0,
      identificacao: '',
      logradouro: '',
      numeroEndereco: '',
      complemento: '',
      bairro: '',
      cidade: '',
      estado: '',
      cep: '',
      capacidade: ''
    },
    mensagem: { 
      texto: '',
      alerta: ''
    }
  }

  setValues = (e, campo) => {
      const { modelo } = this.state
      modelo[campo] = e.target.value
      this.setState({ modelo })
  }

  criar = () => {
    this.setState({ 
      modelo: {
        localReciclagemId: 0,
        identificacao: '',
        logradouro: '',
        numeroEndereco: '',
        complemento: '',
        bairro: '',
        cidade: '',
        estado: '',
        cep: '',
        capacidade: 0.0
      }})
    this.props.locaisCriados(this.state.modelo)
  }

  componentWillMount(){
    PubSub.subscribe('editar-local', (topico, local) => {
      this.setState({ modelo: local })
    })
  }

  render() {
    return (
      <Form>
        <FormGroup>
        <div className="form-row">
            <div className="col-md-4">
              <Label for="localReciclagemId">Id: </Label>
              <Input id="localReciclagemId" type="id" value={this.state.modelo.localReciclagemId} 
                placeholder="0" onChange={e => this.setValues(e, 'description')} disabled/>
            </div>
            <div className="col-md-8">
              <Label for="identificacao">Identificação: </Label>
              <Input id="identificacao" value={this.state.modelo.identificacao} type="text" placeholder="ex: LR-Jardim Industrial" 
                      onChange={e => this.setValues(e, 'identificacao')}/>
            </div>
          </div>
          <div className="form-row">
            <div className="col-md-8">
              <Label for="logradouro">Logradouro: </Label>
              <Input id="logradouro" value={this.state.modelo.logradouro} type="text" placeholder="ex: Av.Brasil" 
                      onChange={e => this.setValues(e, 'logradouro')}/>
            </div>
            <div className="col-md-4">
              <Label for="numeroEndereco">Número: </Label>
              <Input id="numeroEndereco" value={this.state.modelo.numeroEndereco} type="text" placeholder="ex: 145" 
                      onChange={e => this.setValues(e, 'numeroEndereco')}/>
            </div>
          </div>
          <div className="form-row">
            <div className="col-md-7">
              <Label for="bairro">Bairro: </Label>
              <Input id="bairro" value={this.state.modelo.bairro} type="text" placeholder="ex: Parque Ibirapuera" 
                      onChange={e => this.setValues(e, 'bairro')}/>
            </div>
            <div className="col-md-5">
              <Label for="complemento">Complemento: </Label>
              <Input id="complemento" value={this.state.modelo.complemento} type="text" placeholder="ex: Ao lado do parque" 
                      onChange={e => this.setValues(e, 'complemento')}/>
            </div>
          </div>
          <div className="form-row">
            <div className="col-md-6">
              <Label for="cidade">Cidade: </Label>
              <Input id="cidade" value={this.state.modelo.cidade} type="text" placeholder="ex: São Paulo" 
                      onChange={e => this.setValues(e, 'cidade')}/>
            </div>
            <div className="col-md-6">
              <Label for="estado">Estado: </Label>
              <Input id="estado" value={this.state.modelo.estado} maxLength={2} type="text" placeholder="ex: SP" 
                      onChange={e => this.setValues(e, 'estado')}/>
            </div>
          </div>
            <div className="form-row">
              <div className="col-md-6">
                <Label for="cep">CEP: </Label>
                <Input id="cep" value={this.state.modelo.cep} type="number" placeholder="ex: 12222000" 
                        onChange={e => this.setValues(e, 'cep')}/>
              </div>
              <div className="col-md-6">
                <Label for="capacidade">Capacidade: </Label>
                <Input id="capacidade" value={this.state.modelo.capacidade} type="number" placeholder="ex: 500.7" 
                        onChange={e => this.setValues(e, 'capacidade')}/>
              </div>
            </div>
        </FormGroup>

        <Button color="primary" block onClick={this.criar}> Gravar </Button>
      </Form>
    )
  }
}

class ListaDeLocais extends Component {

  deletar = (local) => {
    this.props.deletarLocal(local)
  }

  onEdit = (local) => {
    PubSub.publish('editar-local', local)
  }

  render() {

    const { locais } = this.props

    return (
      <Table className="table-bordered text-center">
        <thead className="thead-dark">
          <tr>
            <th>#</th>
            <th>Identificação</th>
            <th>Logradouro</th> 
            <th>Numero Endereco</th>
            <th>Complemento</th>
            <th>Bairro</th>
            <th>Cidade</th>
            <th>Estado</th>
            <th>CEP</th>
            <th>Capacidade</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {
            locais.map(local => (
              <tr key={local.localReciclagemId}>
                <th>{local.localReciclagemId}</th>
                <th>{local.identificacao}</th>
                <th>{local.logradouro}</th> 
                <th>{local.numeroEndereco}</th>
                <th>{local.complemento}</th>
                <th>{local.bairro}</th>
                <th>{local.cidade}</th>
                <th>{local.estado}</th>
                <th>{local.cep}</th>
                <th>{local.capacidade}</th>
                <td>
                  <Button color="warning" 
                          size="sm" style={{marginTop:"1em", width:"6em", height:"2em"}} 
                          onClick={e => this.onEdit(local)} >Editar</Button>
                  <Button color="danger" 
                          size="sm" style={{marginTop:"1em", width:"6em", height:"2em"}} 
                          onClick={e => this.deletar(local)}>Deletar</Button>
                </td>
              </tr>
            ))
          }
        </tbody>
      </Table>
    )
  }
}

export default class LocaisBox extends Component {

  baseUrl = 'https://localhost:5001/v1/locais'
  posicaoInicial = {
    lat: 0,
    lng: 0
  }

  posicaoSelecionada = {
    lat: 0,
    lng: 0
  }

  state = {
    locais: [],
    mensagem: {
      texto: '',
      alerta: ''
    }
  }

  componentDidMount(){
    fetch(this.baseUrl)
      .then(response => response.json())
      .then(locais => this.setState({locais}))
      .catch(e => console.log(e))
  }

  gravar = (local) => {
    console.log(local)
    let dados = {
      localReciclagemId: local.localReciclagemId,
      identificacao: local.identificacao,
      logradouro: local.logradouro,
      numeroEndereco: local.numeroEndereco,
      complemento: local.complemento,
      bairro: local.bairro,
      cidade: local.cidade,
      estado: local.estado,
      cep: local.cep,
      capacidade: parseFloat(local.capacidade)
    }
    const requestInfo = {
      method: dados.localReciclagemId === 0 ? 'POST' : 'PUT',
      mode: 'cors',
      credentials: 'same-origin',
      cache: 'default',
      body: JSON.stringify(dados),
      headers: new Headers({ 'Content-Type': 'application/json' }),
    };

    if(dados.localReciclagemId === 0) {
      fetch(this.baseUrl, requestInfo)
      .then(response => response.json())
      .then(novoLocal => {
          const { locais } = this.state
          locais.push(novoLocal)
          this.setState({ locais, mensagem: { texto: 'Local adicionado com sucesso!', alerta: 'sucess'} })
          this.tempoMensagem(3000)
      })
      .catch(e => console.log(e))
    } else {
      fetch(this.baseUrl, requestInfo)
      .then(response => response.json())
      .then(editaLocal => {
          const { locais } = this.state
          let posicao = locais.findIndex(local => local.localReciclagemId === dados.localReciclagemId)
          locais[posicao] = editaLocal
          this.setState({ locais, mensagem: { texto: 'Local atualizado com sucesso!', alerta: 'info'} })
          this.tempoMensagem(3000)
      })
      .catch(e => console.log(e))
    }
    this.refreshPage()
  }

  refreshPage() {
    window.location.reload(true);
  }

  deletar = (local) => {
    const requestInfo = {
      method: "DELETE",
      mode: 'cors',
      credentials: 'same-origin',
      cache: 'default',
      body: JSON.stringify(local),
      headers: new Headers({ 'Content-Type': 'application/json' }),
    };
    fetch(this.baseUrl, requestInfo)
      .then(response => response.json())
      .then(rows => {
        const locais = this.state.locais.filter(lo => lo !== local )
        this.setState({ locais, mensagem: { texto: 'Local deletado com sucesso!', alerta: 'danger'} })
        this.tempoMensagem(3000)
      })
      .catch(e => console.log(e))
  }

  tempoMensagem = (duration) => {
    setTimeout(() => {
      this.setState({ mensagem: {texto: '', alerta: ''}})
    }, duration)
  }

  render() {
    return (
      <div id="page-create-point">
        <div>
          {
            this.state.mensagem.texto !== '' ? (
              <Alert color={this.state.mensagem.alerta} className="text-center"> {this.state.mensagem.texto}</Alert>
            ) : ''
          }
        </div>
        <div className="row">
          <div className="col-md-12 my-3">
            <h2 className="font-weight-bold text-center"
                style={{marginTop:"1em"}}> Cadastro de Produtos </h2>
            <FormularioLocais locaisCriados={this.gravar} />
          </div>
        </div>
        <div className="row">
          <div className="col-md-12 my-3">
            <h2 className="font-weight-bold text-center"
                style={{marginTop:"1em"}}> Lista de Produtos </h2>
            <ListaDeLocais locais={this.state.locais} deletarLocal={this.deletar}/>
          </div>
        </div>
      </div>
  
    )
  }
}