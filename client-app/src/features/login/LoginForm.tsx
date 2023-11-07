import { Formik } from "formik";
import { Form } from "react-router-dom";
import MyTextInput from "../../app/common/form/MyTextInput";
import { Button } from "semantic-ui-react";

export default function LoginForm(){
    return (
        <Formik
            initialValues={{email: '', password: ''}}
            onSubmit={values => console.log(values)}
        >
            {({handleSubmit}) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                    <MyTextInput name='email' placeholder='Email'/>
                    <MyTextInput name='password' placeholder='Password' type='password'/>
                    <Button positive content='Login' type='submit' fluid/>
                </Form>
            )} 
        </Formik>
    )
}