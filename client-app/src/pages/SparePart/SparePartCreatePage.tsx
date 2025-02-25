import React from "react";
import {Button, Form, Input, InputNumber, Select} from "antd";
import { ISparePartPostRequest} from "./types.ts";
import TextArea from "antd/es/input/TextArea";
import {useNavigate} from "react-router-dom";
import {useCreateSparePartMutation} from "../../services/apiParts.ts";
import { useGetCategoriesQuery } from "../../services/apiCategory.ts";
import { useGetProvidersQuery } from "../../services/apiProviders.ts";
import { useGetProducersQuery } from "../../services/apiProducers.ts";


const SparePartCreatePage: React.FC = () => {

    const [form] = Form.useForm<ISparePartPostRequest>();
    const navigate = useNavigate();
    const [createSparePart] = useCreateSparePartMutation();
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

    //Знімає дані з форми
    const onFinish = async (values: ISparePartPostRequest) => {
        try {
            console.log("Info",values);
            
            const response = await createSparePart(values).unwrap();
            console.log("Категорія успішно створена:", response);
            navigate("..");
        } catch (error) {
            console.error("Помилка під час додавання деталі:", error);
        }
    }

    return (
        <div className="max-w-xl mx-auto p-6 bg-white shadow-md rounded-lg">
            <h1 className="text-2xl font-bold text-center mb-6">Create Product</h1>
            <button onClick={() => navigate(-1)}
                    className="px-4 py-2 bg-blue-500 text-white rounded-lg shadow-md hover:bg-blue-700 mb-4"
            >
                Go Back
            </button>

            <Form form={form}
                  onFinish={onFinish}
                  layout={"vertical"}
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


                <div className="flex justify-center">
                    <button
                        type="submit"
                        className="bg-blue-500 text-white p-2 rounded w-full md:w-1/2 mt-4"
                    >
                    </button>
                </div>
            </Form>
        </div>
    )
}

export default SparePartCreatePage;