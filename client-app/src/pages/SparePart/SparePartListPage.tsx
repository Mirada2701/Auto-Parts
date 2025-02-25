import {Button, notification} from "antd";
import {Link} from "react-router-dom";
import { useDeleteSparePartMutation, useGetSparePartsQuery } from "../../services/apiParts.ts";
import { EditOutlined } from "@ant-design/icons";


const SparePartListPage = () => {


    const {data: parts, error, isLoading} = useGetSparePartsQuery();

    const [deleteCategory] = useDeleteSparePartMutation();

    const handleDelete = async (id: number) => {
        try {
            await deleteCategory(id).unwrap();
            notification.success({
                message: 'Запчастина видалена',
                description: 'Запчастина успішно видалена!',
            });
        } catch {
            notification.error({
                message: 'Помилка видалення запчастини',
                description: 'Щось пішло не так, спробуйте ще раз.',
            });
        }
    };
    if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error loading categories!</div>;


    const mapData = parts?.map((part) => (
        <tr key={part.id}
            className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
            <td className="px-6 py-4">
                <img width={'100px'} src={part.imageUrl} alt={"image"} />
            </td>
            <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                {part.name}
            </th>

            <td scope="col" className="px-6 py-3">
                {part.description}
            </td>
            <td scope="col" className="px-6 py-3">
                {part.categoryName}
            </td>
            <td scope="col" className="px-6 py-3">
                {part.producerName}
            </td>
            <td scope="col" className="px-6 py-3">
                {part.providerName}
            </td>
            <td scope="col" className="px-6 py-3">
                {part.partNumber}
            </td>
            <td scope="col" className="px-6 py-3">
                {part.quantity}
            </td>
            <td scope="col" className="px-6 py-3">
              {part.isStock ? (
                <span className="inline-flex items-center rounded-md bg-green-50 px-2 py-1 text-xs font-medium text-green-700 ring-1 ring-green-600/20 ring-inset">Доступно</span>
              ):
              (<span className="inline-flex items-center rounded-md bg-red-50 px-2 py-1 text-xs font-medium text-red-700 ring-1 ring-red-600/10 ring-inset">Недоступно</span>)}
            </td>
            <td scope="col" className="px-6 py-3">
                {part.price}$
            </td>
            <td className="px-6 py-4">

                <Button>
                    <Link to={`edit/${part.id}`}>
                        <EditOutlined />
                    </Link>
                </Button>

                <Button
                    type="primary"
                    danger
                    onClick={() => handleDelete(part.id)}
                >
                    Delete
                </Button>
            </td>
        </tr>
    ));


    return (
        <>
            <h1 className={"text-center text-4xl font-bold text-blue-500"}>Список запчастин</h1>
            <Link to={"/parts/create"}
                  className="text-white bg-gradient-to-r from-pink-400 via-pink-500 to-pink-600 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-pink-300 dark:focus:ring-pink-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 mb-2">
                Додати
            </Link>
            <div className="mt-4 relative overflow-x-auto shadow-md sm:rounded-lg">
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                    <tr>
                        <th scope="col" className="px-6 py-3">
                            &nbsp;
                        </th>

                        <th scope="col" className="px-6 py-3">
                            Назва
                        </th>

                        <th scope="col" className="px-6 py-3">
                            Опис
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Категорія
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Виробник
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Постачальник
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Серійний номер
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Кількість
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Наявність
                        </th>
                        <th scope="col" className="px-6 py-3">
                            Ціна
                        </th>
                    </tr>
                    </thead>
                    <tbody>

                    {mapData}
                    </tbody>
                </table>
            </div>

        </>
    )
}

export default SparePartListPage;