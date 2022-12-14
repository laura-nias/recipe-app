import React, { Component, useState } from 'react';
import axios from "axios";


export const ImageUpload = (props) => {
    const [file, setFile] = useState();
    const [fileName, setFileName] = useState();

    const saveFile = (e) => {
        setFile(e.target.files[0]);
        setFileName(e.target.files[0].name)
    };

    const uploadFile = async (e) => {
        const formData = new FormData();
        formData.append("formFile", file);
        formData.append("fileName", fileName);

        props.getFile(fileName);

        try {
            const res = await axios.post("https://localhost:44455/recipe/uploadtest", formData);
            console.log(res);
        } catch (ex) {
            console.log(ex);
        }
    }

    return (
        <>
            <input type="file" onChange={saveFile} />
            <input type="button" value="upload" onClick={uploadFile} />
        </>
    );
};
