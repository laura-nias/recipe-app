import React, { Component } from 'react';
import { ViewRecipe } from "./ViewRecipe";

export class Card extends Component {
    static displayName = Card.name;

    constructor(props) {
        super(props);
        this.state = {
            showModal: false
        }

        this.toggleModal = this.toggleModal.bind(this);
    }

    toggleModal() {
        this.setState({ showModal: !this.state.showModal });
    }

    render() {
        return (
            <div className="card">
                <div className="card-body">
                    <h3 className="card-title">{this.props.recipe.title}</h3>
                    <p className="card-description"><em>{this.props.recipe.description}</em></p>
                    <p className="card-time">{this.props.recipe.time} minutes</p>
                    <button className="btn-card" onClick={this.toggleModal}>View Recipe</button>

                </div>
                {this.state.showModal && (
                    <div>
                        <ViewRecipe showModal={this.toggleModal} recipe={this.props.recipe}/>
                    </div>
                )
                }
            </div>
        );
    }
}
