import React from 'react';
import { Layout, Menu, theme } from 'antd';
import {Link, Outlet} from "react-router-dom";
import { ContactsOutlined, HomeOutlined, InfoCircleOutlined, ProductOutlined } from '@ant-design/icons';

const { Header, Content, Footer } = Layout;

function getItem(label: any, key:string, icon:any) {
    return {
      key,
      icon,
      label,
    };
  }
  const items = [
    getItem(<Link to="/">Головна</Link>, '1', <HomeOutlined />),
    getItem(<Link to="/parts">Запчастини</Link>, '2', <ProductOutlined />),
    getItem(<Link to="/about">About</Link>, '3', <InfoCircleOutlined />),
    getItem(<Link to="/contact">Contacts</Link>, '4', <ContactsOutlined />),
];

const App: React.FC = () => {


    return (
        <Layout className="h-screen flex flex-col">
            <Header className="sticky top-0 z-10 w-full flex items-center bg-gray-800 text-white">
                <div className="demo-logo" />
                <Menu
                    theme="dark"
                    mode="horizontal"
                    defaultSelectedKeys={['1']}
                    items={items}
                    className="flex-1 min-w-0"
                />
            </Header>

            <Content className="flex-1 p-12 bg-gray-100">
                <div className="bg-white min-h-full p-6 rounded-lg shadow-md">
                    <Outlet />
                </div>
            </Content>

            <Footer className="fixed bottom-0 w-full text-center bg-gray-800 text-white p-4">
                Магазин авто-запчастин ©{new Date().getFullYear()}
            </Footer>
        </Layout>
    );
};

export default App;