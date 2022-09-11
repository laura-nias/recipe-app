import React, { Component } from 'react';
import { ImageUpload } from './ImageUpload';
import { RecipeForm } from './RecipeForm';

export class ViewRecipe extends Component {
    constructor(props) {
        super(props);

        this.state = {
            method: "",
            title: "",
            ingredients: "",
            notes: "",
            description: "",
            time: "",
            image: "",
            edit: false
        }

        this.handleEdit = this.handleEdit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.pullData = this.pullData.bind(this);
        this.handleData = this.handleData.bind(this);
    }

    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    handleEdit() {
        this.setState({ edit: true });
    }

    async pullData(data) {
        console.log(data);
        this.setState({
            title: data.title,
            time: data.time,
            description: data.description,
            ingredients: data.ingredients,
            method: data.method,
            notes: data.notes,
            image: data.image_id
        }, () => {
            this.handleData();
        });

    }

    async handleData() {
        
        var formData = new FormData();
        formData.append("title", this.state.title);
        formData.append("description", this.state.description);
        formData.append("time", this.state.time);
        formData.append("ingredients", this.state.ingredients);
        formData.append("method", this.state.method);
        formData.append("notes", this.state.notes);
        formData.append("image", this.state.image);

        const response = await fetch('recipe/edit/' + this.props.recipe.id, {
            method: "PUT",
            body: formData
        });

    }

    async handleDelete() {
        await fetch('recipe/delete/' + this.props.recipe.id, {
            method: 'DELETE'
        });

        window.location.reload(false);
    }

    render() {
        return (
            <>
                <div className="overlay"></div>
                <div className="recipe-modal">
                    <button className="btn-recipe-close" onClick={this.props.showModal}>X</button>
                    {this.state.edit ? <><RecipeForm recipe={this.props.recipe} handleChange={this.handleChange} handleSubmit={this.pullData} edit={this.state.edit} /> <ImageUpload /></> :
                        <>
                            <img className="recipe-image" src={`../Resource/Images/${this.props.recipe.image_id}`}></img>
                            <div className="recipe-header">
                                <h3 className="recipe-title">{this.props.recipe.title}</h3>
                                <h4 className="recipe-description"><em>{this.props.recipe.description}</em></h4>
                                <p className="recipe-time">{this.props.recipe.time} minutes</p>
                            </div>
                            <p className="recipe-ingredients">Ingredients: <br />{this.props.recipe.ingredients}</p>
                            <p className="recipe-method">Method: <br />{this.props.recipe.method}</p>
                            <p className="recipe-notes">Notes: <br />{this.props.recipe.notes}</p>
                            <div className="btn-container">
                                <button className="btn-edit" onClick={this.handleEdit}>Edit</button>
                                <button className="btn-delete" onClick={this.handleDelete}>Delete</button>
                            </div>
                        </>
                    }
                </div>
            </>
        )
    }

}