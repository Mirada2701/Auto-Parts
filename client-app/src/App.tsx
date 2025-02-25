import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import HomePage from "./pages/HomePage";
import AboutPage from "./pages/AboutPage";
import ContactPage from "./pages/ContactPage";
import SparePartListPage from "./pages/SparePart/SparePartListPage";
import SparePartCreatePage from "./pages/SparePart/SparePartCreatePage";
import EditSparePartPage from "./pages/SparePart/EditSparePartPage";




const App: React.FC = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<HomePage />} />
                    <Route path="about" element={<AboutPage />} />
                    <Route path="contact" element={<ContactPage />} />
                    <Route path="parts">
                        <Route index element={<SparePartListPage />} />
                         <Route path="create" element={<SparePartCreatePage />} />
                         <Route path="edit/:id" element={<EditSparePartPage />} />
                    </Route>
                </Route>
            </Routes>
        </Router>
    );
};

export default App;
