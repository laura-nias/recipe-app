import React, { Component } from 'react';
import { Card } from './Card';
import { AddRecipe } from './AddRecipe';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);

        this.state = {
            showModal: false,
            recipes: [],
            loading: true
        }

        this.toggleModal = this.toggleModal.bind(this);
        
    }

    componentDidMount() {
        this.populateRecipeData();
    }

    toggleModal() {
        this.setState({ showModal: !this.state.showModal });
    }

    render() {
        return (
            <div className="main-page">
                <button className="btn-add" onClick={this.toggleModal}>Add New Recipe</button>
                {this.state.showModal && (
                    <div>
                        <AddRecipe showModal={this.toggleModal} />
                    </div>
                )
                }
                <div className="card-container">
                    {this.state.loading ? <p><em>Loading...</em></p> :
                        this.state.recipes.map(recipe =>
                            <Card recipe={recipe} />
                        )}
                </div>
            </div>
        );
    }

    async populateRecipeData() {
        const response = await fetch('recipe');
        const data = await response.json();
        this.setState({ recipes: data, loading: false });
    }
}
