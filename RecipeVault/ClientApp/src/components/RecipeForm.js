import React, { Component } from 'react';
import { ImageUpload } from './ImageUpload';

export class RecipeForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            method: this.props.recipe.method,
            title: this.props.recipe.title,
            ingredients: this.props.recipe.ingredients,
            notes: this.props.recipe.notes,
            description: this.props.recipe.description,
            time: this.props.recipe.time,
        }

        this.handleEdit = this.handleEdit.bind(this);
        this.handletest = this.handletest.bind(this);
    }

    handleEdit(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    handletest() {
        this.props.handleSubmit(this.state)
    }

    render() {
        return (
            <>
                <form className="recipe-form" onSubmit={this.handletest} action="#">
                        <label className="form-label">
                            <h4>Recipe title</h4>
                        <input type="text" name="title" defaultValue={this.state.title} placeholder="Recipe name" onChange={this.state.edit ? this.handleEdit : this.props.handleChange} />
                        </label>
                        <label className="form-label">
                            <h4>Time to make</h4>
                        <input type="number" name="time" defaultValue={this.state.time} placeholder="Enter time in minutes" onChange={this.state.edit ? this.handleEdit : this.props.handleChange} />
                        </label>
                        <label className="form-label">
                            <h4>Description</h4>
                        <textarea name="description" defaultValue={this.state.description} placeholder="Describe your recipe" rows="1"
                            maxLength="500" onChange={this.state.edit ? this.handleEdit : this.props.handleChange} />
                        </label>
                        <label className="form-label">
                            <h4>Ingredients</h4>
                        <textarea name="ingredients" defaultValue={this.state.ingredients} placeholder="Ingredients" rows="4"
                            maxLength="1000" resize="vertical" onChange={this.state.edit ? this.handleEdit : this.props.handleChange} />
                        </label>
                        <label className="form-label">
                            <h4>Method</h4>
                        <textarea name="method" defaultValue={this.state.method} placeholder="Method" rows="4"
                            maxLength="2000" resize="vertical" onChange={this.state.edit ? this.handleEdit : this.props.handleChange} />
                        </label>
                        <label className="form-label">
                            <h4>Notes</h4>
                        <textarea name="notes" defaultValue={this.state.notes} placeholder="Notes" rows="3"
                            maxLength="1000" resize="vertical" onChange={this.state.edit ? this.handleEdit : this.props.handleChange} />
                        </label>
                        <input className="btn-submit" type="submit" value="Submit" />
                    </form>
                </>
            )
    }
}
