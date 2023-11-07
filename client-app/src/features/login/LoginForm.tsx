import { Formik } from "formik";
import { Form } from "react-router-dom";
import MyTextInput from "../../app/common/form/MyTextInput";
import { Button } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";

export default observer(function LoginForm(){
    const {userStore} = useStore();
    return (
        <Formik
            initialValues={{email: '', password: ''}}
            onSubmit={values => userStore.login(values)}
        >
            {({handleSubmit, isSubmitting}) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                    <MyTextInput name='email' placeholder='Email'/>
                    <MyTextInput name='password' placeholder='Password' type='password'/>
                    <Button loading={isSubmitting} positive content='Login' type='submit' fluid/>
                </Form>
            )} 
        </Formik>
    )
})