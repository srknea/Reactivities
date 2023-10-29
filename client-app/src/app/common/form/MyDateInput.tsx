import { useField } from "formik";
import { Form, Label } from "semantic-ui-react";
import DateTimePicker, {ReactDatePickerProps} from "react-datepicker";

export default function MyDateInput(props: Partial<ReactDatePickerProps>){
    const [field, metal, helpers] = useField(props.name!);
    return(
        <Form.Field error={metal.touched && !!metal.error}>
            <DateTimePicker
                {...field}
                {...props}
                selected={(field.value && new Date(field.value)) || null}
                onChange={value => helpers.setValue(value)}
            />
            {metal.touched && metal.error ? (
                <Label basic color='red'>{metal.error}</Label>
            ) : null}
        </Form.Field>
    )
}