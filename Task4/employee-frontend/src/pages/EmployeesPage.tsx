import { useEffect, useState } from "react";
import { getEmployees, createEmployee, updateEmployee, deleteEmployee } from "@/api/employeeApi";
import { getPositions } from "@/api/positionApi";
import EmployeeFormDialog from "@/components/EmployeeFormDialog";
import ConfirmDeleteDialog from "@/components/ConfirmDeleteDialog";
import EmployeesTable from "@/components/EmployeesTable";
import { Button } from "@/components/ui/button";

export default function EmployeesPage() {
    const [employees, setEmployees] = useState<any[]>([]);
    const [positions, setPositions] = useState<any[]>([]);
    const [editing, setEditing] = useState<any | null>(null);
    const [modalOpen, setModalOpen] = useState(false);
    const [deleteConfirmOpen, setDeleteConfirmOpen] = useState(false);

    const load = async () => {
        const e = await getEmployees({ page: 1, pageSize: 50 });
        const p = await getPositions();
        setEmployees(e.data);
        setPositions(p.data);
    };

    useEffect(() => { load(); }, []);

    const handleSave = async (data: any) => {
        if (editing) await updateEmployee(editing.id, data);
        else await createEmployee(data);
        setModalOpen(false);
        setEditing(null);
        load();
    };

    const handleDelete = async () => {
        await deleteEmployee(editing.id);
        setDeleteConfirmOpen(false);
        setEditing(null);
        load();
    };

    return (
        <div className="p-8 space-y-4">
            <div className="flex justify-between">
                <h2 className="text-xl font-semibold">Сотрудники</h2>
                <Button onClick={() => setModalOpen(true)}>➕ Создать</Button>
            </div>
            <EmployeesTable data={employees} onEdit={(e) => { setEditing(e); setModalOpen(true); }} onDelete={(e) => { setEditing(e); setDeleteConfirmOpen(true); }} />
            <EmployeeFormDialog open={modalOpen} onClose={() => { setModalOpen(false); setEditing(null); }} onSave={handleSave} employee={editing} positions={positions} />
            <ConfirmDeleteDialog open={deleteConfirmOpen} onCancel={() => setDeleteConfirmOpen(false)} onConfirm={handleDelete} />
        </div>
    );
}
