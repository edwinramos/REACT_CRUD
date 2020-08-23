import React, { Component } from 'react';
import EditModal from './EditModal';

export class Home extends Component {
    static displayName = Home.name;
    state = {
        rows: [], loading: true, editModal: false, objEdit: {}
    };

    constructor(props) {
        super(props);


        this.closeModal = this.closeModal.bind(this);
    }

    componentDidMount() {
        this.populateData();
    }

    render() {

        return (
            <div>
                <h1 id="tabelLabel" >Permisos</h1>
                <button onClick={() => this.editPopup(0)} className="btn btn-primary">Agregar</button>
                <div>
                    <table className='table table-striped' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Nombre Empleado</th>
                                <th>Fecha Permiso</th>
                                <th>Tipo Permiso</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.rows.map(row =>
                                <tr key={row.id}>
                                    <td>{row.nombreEmpleado}</td>
                                    <td>{row.fechaPermiso}</td>
                                    <td>{row.tipoPermiso}</td>
                                    <td><button onClick={() => { this.editPopup(row.id) }} className="btn btn-primary">Editar</button> <button onClick={() => { this.deleteRow(row.id) }} className="btn btn-danger">Borrar</button></td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                    <EditModal onClose={() => { this.closeModal() }} objEdit={this.state.objEdit} isOpen={this.state.editModal} />
                </div>
            </div>
        );
    }

    async populateData() {
        const response = await fetch('crud/getPermisos');
        const data = await response.json();

        this.setState({ rows: data, editModal: false, loading: false });
    }

    async closeModal() {
        this.setState({ editModal: false, loading: true });
        this.populateData();
    }

    async editPopup(id) {
        const response = await fetch('crud/getPermiso/' + id);
        const data = await response.json();
        console.log(data);
        this.setState({ editModal: true, objEdit: data });
    }

    async deleteRow(id) {
        var res = window.confirm("Would you like to delete this row?");
        if (res === true) {
            const requestOptions = {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                }
            };
            fetch('crud/deletePermiso/' + id, requestOptions)
                .then(
                    (result) => {
                        this.populateData();
                    },
                    (error) => {
                        console.log(error);
                    });
        }
    }
}
