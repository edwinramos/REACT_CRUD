import React, { Component } from 'react';
import { Modal, Col, Form } from "react-bootstrap";
import ReactDOM from 'react-dom';

class EditModal extends Component {

    state = { tiposPermiso: [{id:0, descripcion:""}], loading: true };
    constructor(props) {
        super(props);

        this.onSave = this.onSave.bind(this);
    }

    componentDidMount() {
        this.populateTiposPermiso();
    }

    async populateTiposPermiso() {
        const response = await fetch('crud/getTiposPermiso');
        const data = await response.json();
        console.log(data);
        this.setState({ tiposPermiso: data });
    }

    onSave(onClose) {
        var obj = {};
        Object.keys(this.refs)
            .filter(key => key === 'frm_edit')
            .forEach(key => {
                obj = {
                    Id: Number(ReactDOM.findDOMNode(this.refs[key]).elements.ID.value),
                    NombreEmpleado: ReactDOM.findDOMNode(this.refs[key]).elements.NombreEmpleado.value,
                    ApellidosEmpleado: ReactDOM.findDOMNode(this.refs[key]).elements.ApellidosEmpleado.value,
                    TipoPermisoId: Number(ReactDOM.findDOMNode(this.refs[key]).elements.TipoPermisoId.value),
                };
            });
        console.log(obj);
        var url = 'crud/postPermiso';
        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(obj)
        };
        fetch(url, requestOptions)
            .then(
                (result) => {
                    onClose();
                },
                (error) => {
                    console.log(error);
                });
    }

    render() {
        const { onClose, objEdit, isOpen } = this.props // destructure

        return (
            <Modal
                size="lg"
                show={isOpen}
                onHide={() => onClose()}
                aria-labelledby="example-modal-sizes-title-lg">
                <Modal.Header closeButton>
                    <Modal.Title id="example-modal-sizes-title-lg">
                        Edit
            </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form ref={'frm_edit'}>
                        <Form.Group controlId="ID">
                            <Form.Control type="hidden" defaultValue={objEdit.id} />
                        </Form.Group>
                        <Form.Row>
                            <Col>
                                <Form.Group controlId="NombreEmpleado">
                                    <Form.Label>Nombre(s)</Form.Label>
                                    <Form.Control defaultValue={objEdit.nombreEmpleado}>

                                    </Form.Control>
                                </Form.Group>
                            </Col>
                            <Col>
                                <Form.Group controlId="ApellidosEmpleado">
                                    <Form.Label>Apellidos</Form.Label>
                                    <Form.Control defaultValue={objEdit.apellidosEmpleado}>

                                    </Form.Control>
                                </Form.Group>
                            </Col>
                            <Col>
                                <Form.Group controlId="TipoPermisoId">
                                    <Form.Label>Tipo Permiso</Form.Label>
                                    <Form.Control as="select" defaultValue={objEdit.tipoPermisoId}>
                                        {this.state.tiposPermiso.map((itm) => {
                                            return <option value={itm.id}>{itm.descripcion}</option>
                                        })}
                                    </Form.Control>
                                </Form.Group>
                            </Col>
                        </Form.Row>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <button onClick={() => this.onSave(onClose)} className="btn btn-success">Guardar</button>
                </Modal.Footer>
            </Modal>
        );
    }
}
export default EditModal;