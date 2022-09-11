import React, { Component } from 'react';
import { ImageUpload } from './ImageUpload';
import { RecipeForm } from './RecipeForm';

export class AddRecipe extends Component {
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
            loading: true,
            recipes: ""
        }

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.getFile = this.getFile.bind(this);
    }

    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    async getFile(data) {
        this.setState({ image: data })
    }

    async handleSubmit(e) {

        var formData = new FormData();
        formData.append("title", this.state.title);
        formData.append("description", this.state.description);
        formData.append("time", this.state.time);
        formData.append("ingredients", this.state.ingredients);
        formData.append("method", this.state.method);
        formData.append("notes", this.state.notes);
        formData.append("image", this.state.image);

        const response = await fetch('recipe/postcipe', {
            method: "POST",
            body: formData
        });

        const data = await response.json();
        this.setState({ recipes: data, loading: false });
    }

    render() {
        return (
            <>
                <div className="overlay"></div>
                <div className="modal">
                    <button className="btn-close" onClick={this.props.showModal}>X</button>
                    <h3 >Add New Recipe</h3>
                    <RecipeForm recipe={this.state} handleChange={this.handleChange} handleSubmit={this.handleSubmit} />
                    <ImageUpload getFile={this.getFile} />
                </div>
            </>
        );
    }

}
