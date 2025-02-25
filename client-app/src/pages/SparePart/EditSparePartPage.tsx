import { Form, Input, Button, notification, Select } from 'antd';
import TextArea from "antd/es/input/TextArea";
import {useNavigate, useParams} from "react-router-dom";
import { useGetSparePartQuery, useUpdateSparePartMutation } from '../../services/apiParts';
import { ISparePartPutRequest } from './types';
import { useGetCategoriesQuery } from '../../services/apiCategory';
import { useGetProvidersQuery } from '../../services/apiProviders';
import { useGetProducersQuery } from '../../services/apiProducers';
import { useEffect } from 'react';

const { Item } = Form;

const EditSparePartPage = () => {

    
    const { id } = useParams<{ id: string }>();

    const { data: part} = useGetSparePartQuery(Number(id));
    console.log(part);
    

    const [updateCategory] = useUpdateSparePartMutation();

    const [form] = Form.useForm<ISparePartPutRequest>();

    useEffect(() => {
        if (part) {
            form.setFieldsValue({
                name: part.name,
                imageUrl: part.imageUrl,
                categoryId: part.categoryId,
                producerId: part.producerId,
                providerId: part.providerId,
                partNumber: part.partNumber,
                description: part.description || '',
                quantity: part.quantity,
                price: part.price,
            });
        }
    }, [part, form]);

     const {data: categories} = useGetCategoriesQuery();
        const {data: providers} = useGetProvidersQuery();
        const {data: producers} = useGetProducersQuery();
    
        const categoriesData = categories?.map(item => ({
            label: item.name,
            value: item.id,
        }));
        const providersData = providers?.map(item => ({
            label: item.name,
            value: item.id,
        }));
        const producersData = producers?.map(item => ({
            label: item.name,
            value: item.id,
        }));

    const navigation = useNavigate();

    const onFinish = async (values: ISparePartPutRequest) => {
        try {
            const part = await updateCategory({...values, id: Number(id)}).unwrap();
            console.log("Update part", part);
            navigation("/parts");

        } catch (err) {
            console.error("Помилка редагування запчастини:", err);
            notification.error({
                message: 'Помилка редагування запчастини',
                description: 'Щось пішло не так, спробуйте ще раз.',
            });
        }
    };


    return (
        <div style={{maxWidth: '400px', margin: '0 auto'}}>
            <h1 className="text-center text-4xl font-extrabold text-transparent bg-clip-text bg-gradient-to-r from-blue-500 to-purple-500 my-6">
                Зміна запчастини
            </h1>
            <Form
                form={form}
                onFinish={onFinish}
                layout="vertical"
                // initialValues={{
                //     name: part?.name || '',
                //     imageUrl: part?.imageUrl || '',
                //     categoryId: part?.categoryId || undefined,
                //     producerId: part?.producerId || undefined,
                //     providerId: part?.providerId || undefined,
                //     partNumber: part?.partNumber || '',
                //     description: part?.description || '',
                //     quantity: part?.quantity || 0,
                //     price: part?.price || 0,
                // }}
            >
                <Form.Item
                    label="Назва"
                    name="name"
                    htmlFor="name"
                    rules={[
                        {required: true, message: "It is a required field!"},
                        {min: 3, message: "Name must have at least 3 symbols!"},
                    ]}
                >
                    <Input
                        autoComplete="name"
                        className={
                            "w-full p-2 border border-gray-300 rounded mt-2"
                        }
                    />
                </Form.Item>
                <Form.Item
                    label="Картинка"
                    name="imageUrl" 
                    htmlFor="imageUrl"                   
                >
                    <Input
                        autoComplete="imageUrl"
                        className={
                            "w-full p-2 border border-gray-300 rounded mt-2"
                        }
                    />
                </Form.Item>

                
                    <Form.Item
                        label="Категорія"
                        name="categoryId"
                        htmlFor="categoryId"
                        rules={[{required: true, message: "Це поле є обов'язковим!"}]}
                    >
                        <Select placeholder="Оберіть категорію: " options={categoriesData}/>
                    </Form.Item>

                    <Form.Item
                        label="Виробник"
                        name="producerId"
                        htmlFor="producerId"
                        rules={[{required: true, message: "Це поле є обов'язковим!"}]}
                    >
                        <Select placeholder="Оберіть виробника: " options={producersData}/>
                    </Form.Item>

                    <Form.Item
                        label="Постачальник"
                        name="providerId"
                        htmlFor="providerId"
                        rules={[{required: true, message: "Це поле є обов'язковим!"}]}
                    >
                        <Select placeholder="Оберіть постачальника: " options={providersData}/>
                    </Form.Item>
                    
                    <Form.Item
                    label="Артикул"
                    name="partNumber"
                    htmlFor="partNumber"
                >
                    <Input
                        autoComplete="partNumber"
                        className={
                            "w-full p-2 border border-gray-300 rounded mt-2"
                        }
                    />
                </Form.Item>

                    <Form.Item
                    label="Опис"
                    name="description"
                    htmlFor="description"
                    rules={[
                        {required: true, message: "It is a required field!"},
                    ]}
                >
                    <TextArea
                        rows={4}
                        placeholder="Введіть текст..."
                        maxLength={200}
                        allowClear
                    />
                </Form.Item>
                
                    <Form.Item
                    label="Кількість"
                    name="quantity"
                    htmlFor="quantity"
                    rules={[
                        {required: true, message: "It is a required field!"},
                    ]}
                >
                    <Input
                        autoComplete="quantity"
                        className={
                            "w-full p-2 border border-gray-300 rounded mt-2"
                        }
                    />
                </Form.Item>

                <Form.Item
                    label="Ціна"
                    name="price"
                    htmlFor="price"
                    rules={[
                        {required: true, message: "It is a required field!"},
                    ]}
                >
                    <Input
                        autoComplete="price"
                        className={
                            "w-full p-2 border border-gray-300 rounded mt-2"
                        }
                    />
                </Form.Item>

                <Item>
                    <Button type="primary" htmlType="submit" block>
                        Оновити категорію
                    </Button>
                </Item>
            </Form>
        </div>
    );
};

export default EditSparePartPage;